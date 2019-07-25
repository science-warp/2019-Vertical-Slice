using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithRotation : MonoBehaviour
{
    public GameObject ObjectToFollow;
    private Vector3 offset;
    private Quaternion rotOffset;

    public float transitionTime = 4;

    private float transitionIncrement;

    public bool isTransitioning = false;

    private void Start()
    {
        //calculate offset
        offset = transform.position - ObjectToFollow.transform.position;
    }

    public void newFollow(GameObject NewObjectToFollow, bool needsTransition)
    {
        ObjectToFollow = NewObjectToFollow;
        if (needsTransition)
        {
            StartCoroutine(SmoothTransition(NewObjectToFollow));
        }
    }

    //moves camera to a new object with the same offset
    public IEnumerator SmoothTransition(GameObject newFollow)
    {
        isTransitioning = true;
        Vector3 endpoint = newFollow.transform.position + offset;

        transitionIncrement = Vector3.Distance(endpoint, transform.position) / transitionTime;

        float returnTime = 0;
        while (returnTime < transitionTime)
        {
            returnTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endpoint, transitionIncrement * Time.deltaTime);
            yield return null;
        }
        isTransitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning)
        {
            transform.position = ObjectToFollow.transform.position + offset;
        }
    }
}
