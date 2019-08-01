using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float rotationDegrees = 207
        ;

    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    Cinemachine.CinemachineOrbitalTransposer cameraControl;

    public float degreeDelta = 5;


    float radius;

    // Start is called before the first frame update
    void Start()
    {


        cameraControl = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineOrbitalTransposer>();

        radius = Vector3.Distance(transform.position, cameraControl.FollowTarget.transform.position);
        rotationDegrees = cameraControl.m_Heading.m_Bias;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Q))
        {
            rotationDegrees += degreeDelta * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.E))
        {
            rotationDegrees -= degreeDelta * Time.deltaTime;
        }

        if(rotationDegrees > 180)
        {
            rotationDegrees -= 360;
        }
        else if(rotationDegrees < -180)
        {
            rotationDegrees += 360;
        }
        


        cameraControl.m_Heading.m_Bias = rotationDegrees;
    }
}
