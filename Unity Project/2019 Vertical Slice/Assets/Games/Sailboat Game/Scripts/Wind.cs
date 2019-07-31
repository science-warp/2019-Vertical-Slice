using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public float windStrength = 60;

    bool isOn = false;

    public ParticleSystem leaves;
    public ParticleSystem air;

    ParticleSystem.MainModule leafMain;
    ParticleSystem.MainModule airMain;

    // Start is called before the first frame update
    void Start()
    {
        airMain = air.main;
        leafMain = leaves.main;
        ToggleWind();
    }

    public void ToggleWind()
    {
        if (isOn)
        {
            //turn off
            leaves.gameObject.SetActive(false);
            air.gameObject.SetActive(false);
        }
        else
        {
            //turn on
            leaves.gameObject.SetActive(true);
            air.gameObject.SetActive(true);
        }
    }

    public void setWind(Vector3 direction, float speed)
    {
        transform.eulerAngles = direction;

        leafMain.startSpeed = speed;
        airMain.startSpeed = speed;
    }
}
