using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBase : MonoBehaviour
{

    public Transform[] points;
    LineRenderer lr;

    public Transform sailboat;

    // Start is called before the first frame update
    void Start()
    {

        Vector3[] pos = new Vector3[points.Length];

        for(int i = 0; i < points.Length; i++)
        {
            pos[i] = points[i].position;


        }

        lr = GetComponent<LineRenderer>();

        lr.SetPositions(pos);

        transform.parent = sailboat;
    }

    // Update is called once per frame
    void Update()
    {
        

        //lr.SetPositions(new Vector3[] { points[0].position, points[1].position, points[2].position, points[3].position });
    }
}
