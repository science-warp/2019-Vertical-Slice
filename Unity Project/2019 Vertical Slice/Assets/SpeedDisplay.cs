using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{

    OptionsManager _optionsManager;

    public TextMeshProUGUI speedValue;
    public TextMeshProUGUI speedUnits;

    public GameObject sailboat;

    Vector3 prevPos;
    Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        //find the optionsManager to get the unit settings. If coming from menu, this should already exist and the one in-scene will destroy itself. Otherwise, it'll use the one in-scene.
        _optionsManager = GameObject.FindObjectOfType<OptionsManager>();

        //set the speed units display.
        string units = "mph";
        switch(_optionsManager.currentSpeedUnit)
        {
            case OptionsManager.speedUnit.KTS:
                units = "kts";
                break;
            case OptionsManager.speedUnit.MPS:
                units = "mps";
                break;
            default:
                break;
                
        }

        speedUnits.text = units;



        prevPos = sailboat.transform.position;
        currentPos = sailboat.transform.position;

    }

    private void Update()
    {
        currentPos = sailboat.transform.position;
        //calculate speed in mps then convert, if need be.
        float velocity = Vector3.Distance(currentPos, prevPos) / Time.deltaTime;

        //so we have the mps
        switch (_optionsManager.currentSpeedUnit)
        {
            case OptionsManager.speedUnit.KTS:
                velocity *= 1.94384f;
                break;
            case OptionsManager.speedUnit.MPS:
                velocity *= 2.23694f;
                break;
            default:
                break;

        }

        //now we need an integer so we don't hate ourselves
        speedValue.text = ((int)velocity).ToString();

        prevPos = currentPos;
    }
}
