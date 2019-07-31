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
        
    }
}
