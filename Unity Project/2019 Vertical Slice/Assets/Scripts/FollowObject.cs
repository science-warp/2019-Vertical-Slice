using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject ObjectToFollow;
    private Vector3 offset;


    private void Start()
    {
        //calculate offset
        offset = transform.position - ObjectToFollow.transform.position;
    }

    public void newFollow (GameObject NewObjectToFollow)
    {
        ObjectToFollow = NewObjectToFollow;
        offset = transform.position - ObjectToFollow.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = ObjectToFollow.transform.position + offset;
    }
}
