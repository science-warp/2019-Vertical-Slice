using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullRenderer : MonoBehaviour
{
    //NOTE: This script is not currently in use but has been left in the project as reference.
    public MeshRenderer meshRenderer;

    public Transform sailboatObject;

    bool isRendering = true;

    float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check rotation
        float angleAbs = Mathf.Abs(WrapAngle(sailboatObject.eulerAngles.z));

        if (angleAbs > 20)
        {
            if (isRendering)
            {
                isRendering = false;
                meshRenderer.enabled = false;
            }
        }
        else
        {
            if (!isRendering)
            {
                isRendering = true;
                meshRenderer.enabled = true;
            }
        }
    }
}
