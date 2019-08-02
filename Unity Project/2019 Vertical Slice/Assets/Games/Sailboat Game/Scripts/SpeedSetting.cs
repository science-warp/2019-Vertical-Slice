using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedSetting : MonoBehaviour
{
    public OptionsManager.speedUnit currentlySelected;

    OptionsManager _optionsManager;

    public TextMeshProUGUI valueText;

    //public Image centerImage;

    //public Sprite mph;
    //public Sprite mps;
    //public Sprite kts;


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

        OptionsManager.speedUnit newUnits = OptionsManager.speedUnit.MPH;


        switch(currentlySelected)
        {
            case OptionsManager.speedUnit.MPH:
                valueText.text = "kts";
                newUnits = OptionsManager.speedUnit.KTS;
                break;

            case OptionsManager.speedUnit.KTS:
                valueText.text = "mps";
                newUnits = OptionsManager.speedUnit.MPS;
                break;

            case OptionsManager.speedUnit.MPS:
                valueText.text = "mph";
                newUnits = OptionsManager.speedUnit.MPH;
                break;
              

        }

        currentlySelected = newUnits;
    }

    public void scrollRight()
    {
        OptionsManager.speedUnit newUnits = OptionsManager.speedUnit.MPH;


        switch (currentlySelected)
        {
            case OptionsManager.speedUnit.MPH:
                valueText.text = "mps";
                newUnits = OptionsManager.speedUnit.MPS;
                break;

            case OptionsManager.speedUnit.KTS:
                valueText.text = "mph";
                newUnits = OptionsManager.speedUnit.MPH;
                break;

            case OptionsManager.speedUnit.MPS:
                valueText.text = "kts";
                newUnits = OptionsManager.speedUnit.KTS;
                break;


        }

        currentlySelected = newUnits;
    }

    public void saveSelection()
    {
        _optionsManager.setSpeedUnits(currentlySelected);
    }
}
