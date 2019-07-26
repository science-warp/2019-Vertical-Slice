using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLine : MonoBehaviour
{

    public Transform leftAnchor;
    public Transform rightAnchor;

    public Transform boomAnchor;

    public LineRenderer boomLineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        boomLineRenderer.SetPositions(new Vector3[] { leftAnchor.position, boomAnchor.position, rightAnchor.position });
    }

    // Update is called once per frame
    void Update()
    {
        boomLineRenderer.SetPositions(new Vector3[] {leftAnchor.position, boomAnchor.position, rightAnchor.position });
    }
}
