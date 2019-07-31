using System.Collections;
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
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, (-1* sailboatObject.transform.rotation.y), transform.rotation.w);
  
    }
}
