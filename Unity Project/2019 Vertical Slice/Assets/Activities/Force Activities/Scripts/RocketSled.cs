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

    public float velocityThreshold = 1;

    public GameObject loadPrefab;

    private Vector3 loadPosition;

    private void Start()
    {

        loadPosition = load.transform.position;

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
    }

    public void LaunchSled()
    {
        StartCoroutine(LaunchSledCoroutine());
    }

    public void LaunchSled(float force)
    {
        forceToApply = force;

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
        followCamera.newFollow(load.gameObject, false);
        load.transform.parent = null;
        load.AddForce(new Vector3(forceToApply, 0, 0));


        while(load.velocity.magnitude > velocityThreshold)
       {
            //do nothing, yay
        }


        StartCoroutine(returnSledCoroutine());

    }

    private IEnumerator returnCamera()
    {
        yield return new WaitForSeconds(5);
        followCamera.newFollow(gameObject, true);
    }

    private IEnumerator returnSledCoroutine()
    {
        foreach (GameObject p in rocketParticles)
        {
            p.SetActive(false);
        }
       // yield return new WaitForSeconds(2);
        StartCoroutine(returnCamera());
       
        float returnTime = 0;
        while (returnTime < launchTime)
        {
            returnTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPoint, secondIncrement * Time.deltaTime);
            yield return null;
        }

        //spawn a new weight
        GameObject newLoad = Instantiate(loadPrefab, loadPosition, Quaternion.identity, transform);
        load = newLoad.GetComponent<Rigidbody>();
    }

}
