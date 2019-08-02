using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{

    public enum speedUnit { MPH, KTS, MPS};

    public enum distanceUnit { M, FT};

    public speedUnit currentSpeedUnit = speedUnit.MPH;
    public distanceUnit currentDistanceUnit = distanceUnit.FT;

    // Start is called before the first frame update
    void Start()
    {
        //this thing sticks around the whole time, unless one already exists. Yay singletons

        if(GameObject.FindObjectsOfType<OptionsManager>().Length > 1)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }


    /// <summary>
    /// Sets the speed units to be used.
    /// </summary>
    /// <param name="unitToUse">the speedUnit to use</param>
    public void setSpeedUnits(speedUnit unitToUse)
    {
        currentSpeedUnit = unitToUse;

    }

    /// <summary>
    /// Sets the distance units to be used.
    /// </summary>
    /// <param name="unitToUse">The distanceUnit to use</param>
    public void setDistanceUnits(distanceUnit unitToUse)
    {
        currentDistanceUnit = unitToUse;

    }
    
}
