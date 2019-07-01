using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSled : MonoBehaviour
{
    public GameObject[] rocketParticles;
    public Vector3 endPoint;
    public Vector3 startPoint;

    public float launchTime;

    public Rigidbody load;

    public float forceToApply = 25;

    public float secondIncrement;

    public FollowObject followCamera;

    private void Start()
    {
        followCamera.ObjectToFollow = gameObject;
        startPoint = transform.position;
        foreach(GameObject p in rocketParticles)
        {
            p.SetActive(false);
        }

        secondIncrement = Vector3.Distance(endPoint, startPoint) / launchTime;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchSled();
        }
    }

    public void LaunchSled()
    {
        StartCoroutine(LaunchSledCoroutine());
    }

    private IEnumerator LaunchSledCoroutine()
    {
        float time = 0;
        foreach (GameObject p in rocketParticles)
        {
            p.SetActive(true);
        }

        while(time < launchTime)
        {
            time += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPoint, secondIncrement * Time.deltaTime);
            yield return null;
        }
        followCamera.newFollow(load.gameObject);
        load.transform.parent = null;
        load.AddForce(new Vector3(forceToApply, 0, 0));

        StartCoroutine(returnSledCoroutine());

    }

    private IEnumerator returnSledCoroutine()
    {
        foreach (GameObject p in rocketParticles)
        {
            p.SetActive(false);
        }
        yield return new WaitForSeconds(2);
       
        float returnTime = 0;
        while (returnTime < launchTime)
        {
            returnTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPoint, secondIncrement * Time.deltaTime);
            yield return null;
        }
    }

}
