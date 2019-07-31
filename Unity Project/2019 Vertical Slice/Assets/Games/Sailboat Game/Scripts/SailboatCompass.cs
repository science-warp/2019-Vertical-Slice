﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailboatCompass : MonoBehaviour
{

    public Transform sailboatObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //adjusts the appearance of the boat icon in accordance to the real boat's rotation 
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (-1*sailboatObject.transform.eulerAngles.y));
  
    }
}
