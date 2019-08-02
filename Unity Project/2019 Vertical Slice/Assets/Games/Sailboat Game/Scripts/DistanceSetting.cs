using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceSetting : MonoBehaviour
{
    public OptionsManager.distanceUnit currentlySelected;

    OptionsManager _optionsManager;

    //public Sprite m;
    //public Sprite ft;

    public TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        _optionsManager = GameObject.FindObjectOfType<OptionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scrollLeft()
    {
        OptionsManager.distanceUnit newUnits = OptionsManager.distanceUnit.FT;


        switch (currentlySelected)
        {
            case OptionsManager.distanceUnit.FT:
                valueText.text = "m";
                newUnits = OptionsManager.distanceUnit.M;
                break;

            case OptionsManager.distanceUnit.M:
                valueText.text = "ft";
                newUnits = OptionsManager.distanceUnit.FT;
                break;
                

        }

        currentlySelected = newUnits;
    }

    public void scrollRight()
    {
        OptionsManager.distanceUnit newUnits = OptionsManager.distanceUnit.FT;


        switch (currentlySelected)
        {
            case OptionsManager.distanceUnit.FT:
                valueText.text = "m";
                newUnits = OptionsManager.distanceUnit.M;
                break;

            case OptionsManager.distanceUnit.M:
                valueText.text = "ft";
                newUnits = OptionsManager.distanceUnit.FT;
                break;


        }

        currentlySelected = newUnits;
    }

    public void saveSelection()
    {
        _optionsManager.setDistanceUnits(currentlySelected);
    }
}
