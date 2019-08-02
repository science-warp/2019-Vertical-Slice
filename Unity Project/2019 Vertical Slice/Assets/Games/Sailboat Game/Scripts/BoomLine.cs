using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLine : MonoBehaviour
{

    public Transform bottomAnchor;

    public Transform boomAnchor;

    public LineRenderer boomLineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        boomLineRenderer.SetPositions(new Vector3[] { bottomAnchor.position, boomAnchor.position});
    }

    // Update is called once per frame
    void Update()
    {
        boomLineRenderer.SetPositions(new Vector3[] { bottomAnchor.position, boomAnchor.position});
    }
}
