using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    //the object that should be followed and the calculated offset
    public GameObject ObjectToFollow;
    private Vector3 offset;


    //how long should the transition take?
    public float transitionTime = 4;


    //how far does the object need to go per second to get to its new spot?
    private float transitionIncrement;

    //don't modify from externally
    public bool isTransitioning = false;

    private void Start()
    {
        //calculate offset
        offset = transform.position - ObjectToFollow.transform.position;
    }

    /// <summary>
    /// Assigns a new object for the object the script is attached to to follow
    /// </summary>
    /// <param name="NewObjectToFollow">The new object to be followed</param>
    /// <param name="needsTransition">Set to "true" if following the new object means that the camera will have to move to a new position</param>
    public void newFollow (GameObject NewObjectToFollow, bool needsTransition)
    {
        ObjectToFollow = NewObjectToFollow;
        if (needsTransition)
        {
            StartCoroutine(SmoothTransition(NewObjectToFollow));
        }
    }


    /// <summary>
    /// moves camera to a new object with the same offset
    /// </summary>
    /// <param name="newFollow">The new object to follow</param>
    /// <returns></returns>
    public IEnumerator SmoothTransition(GameObject newFollow)
    {
        //don't call the movement in Update() while this coroutine is active
        isTransitioning = true;

        //calculate the place the camera needs to move to
        Vector3 endpoint = newFollow.transform.position + offset;

        //calculate how far the camera needs to go per second
        transitionIncrement = Vector3.Distance(endpoint, transform.position) / transitionTime;

        //this is just a glorified timer that moves the camera correctly
        float returnTime = 0;
        while (returnTime < transitionTime)
        {
            returnTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endpoint, transitionIncrement * Time.deltaTime);
            yield return null;
        }
        //ok, go back to the movement in Update() now
        isTransitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //move to follow the object as long as we're not transitioning
        if (!isTransitioning)
        {
            transform.position = ObjectToFollow.transform.position + offset;
        }
    }
}
