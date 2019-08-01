using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailControl : MonoBehaviour
{



    [Range(-100f, 100f)]
    public float billowAmount = 0;

    public float animatorParam = 1;

    public Animator sailAnimator;

    public SkinnedMeshRenderer sailRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(billowAmount > 0)
        {
            sailRenderer.SetBlendShapeWeight(1, billowAmount);
            sailRenderer.SetBlendShapeWeight(0, 0);
        }
        else if(billowAmount < 0)
        {
            sailRenderer.SetBlendShapeWeight(0, Mathf.Abs(billowAmount));
            sailRenderer.SetBlendShapeWeight(1, 0);
        }
        else
        {
            sailRenderer.SetBlendShapeWeight(0, 0);
            sailRenderer.SetBlendShapeWeight(1, 0);
        }


        animatorParam = (Mathf.Abs(billowAmount)) / 100;
        sailAnimator.SetFloat("BillowAmount", animatorParam);
    }
}
