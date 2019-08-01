using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DepthArrowControl : MonoBehaviour
{

    public RectTransform arrowTop;
    public RectTransform arrowBottom;

    public Image arrowTopImage;
    public Image arrowBottomImage;

    //percentage interval variables for resizing/moving parts of the arrow
    float topScaleStepSize;
    float bottomPosStepSize;

    //the size of color/depth steps in the contour/depth map. Calculated based upon max depth and number of color values.
    float colorStepSize;

    public TMPro.TextMeshProUGUI depthValue;
    public TextMeshProUGUI depthUnits;

    [Tooltip("The 0th element is for the shallowest depth, and the nth is for deepest depth. This assumes consistently sized depth steps")]
    public Color[] depthColors;

    [Tooltip("The transform position of the bottom part of the arrow at the shallowest point on the map")]
    public float shallowestArrowPos;

    [Tooltip("The transform y-scale of the top part of the arrow at the shallowest point on the map")]
    public float shallowestArrowHeight;

    [Tooltip("The transform position of the bottom part of the arrow at the deepest point on the map")]
    public float deepestArrowPos;

    [Tooltip("The transform y-scale of the top part of the arrow at the deepest point on the map")]
    public float deepestArrowHeight;


    [Tooltip("Tracks the water's depth under the boat as a percentage of the depth range of the map. /n For example, if the boat is in 4m deep water and the deepest part of the map is 200m deep, this number will be 2.0.")]
    public float currentDepthPercentage;

    [Tooltip("The depth of the deepest part of the map.")]
    public float maxDepth;

    OptionsManager _optionsManager;


    // Start is called before the first frame update
    void Start()
    {

        //oh hey we need units!
        _optionsManager = GameObject.FindObjectOfType<OptionsManager>();

        string units = "ft";
        float multiplier = 1f;

        switch (_optionsManager.currentDistanceUnit)
        {
            case OptionsManager.distanceUnit.M:
                multiplier *= 0.3048f;
                units = "m";
                break;
            default:
                break;

        }

        depthUnits.text = units;

        //multiply maxDepth because it's set in feet and I don't wanna commit a murder
        maxDepth *= multiplier;

        //set up the starting specs
        setDepth(maxDepth);

        //calculate step sizes;

        topScaleStepSize = (deepestArrowHeight - shallowestArrowHeight) / 100f;
        bottomPosStepSize = (deepestArrowPos - shallowestArrowPos) / 100f;

        arrowTop.localScale = new Vector3(arrowTop.localScale.x, shallowestArrowHeight, arrowTop.localScale.z);
        arrowBottom.anchoredPosition = new Vector3(arrowBottom.anchoredPosition.x, shallowestArrowPos);
    }

    //
    /// <summary>
    /// Allows for the maximum depth to be changed. I don't know why you'd need this, but it's here if you want it.
    /// </summary>
    /// <param name="newMaxDepth">The new value of maxDepth</param>
    public void setDepth(float newMaxDepth)
    {
        //set maxDepth variable
        maxDepth = newMaxDepth;

        //adjust step size.
        colorStepSize = maxDepth / depthColors.Length;
    }

    //this should be called in the Update function of the boat
    /// <summary>
    /// Updates the visuals given the depth of the water the boat is in at a given moment
    /// </summary>
    /// <param name="depth">Current water depth.</param>
    public void updateDepth(float depth)
    {
        //calculate percentage
        currentDepthPercentage = depth / maxDepth * 100f;

        //update text component
        depthValue.text = ((int)depth).ToString(); //the units will likely have to be modified at some point 

        //handle sizing
        //set height of top portion
        float newPos = shallowestArrowPos + (bottomPosStepSize * currentDepthPercentage);
        

        arrowTop.localScale = (new Vector3(arrowTop.localScale.x, shallowestArrowHeight + (topScaleStepSize * currentDepthPercentage), arrowTop.localScale.z));

        //set position of bottom portion (and text, which is a child of bottom portion)
        arrowBottom.anchoredPosition = (new Vector3(arrowBottom.anchoredPosition.x, newPos));


        //now we handle the color.
        //first determine which step.
        int colorStepNumber = (int)Mathf.Floor(depth / colorStepSize);

        //clamp to prevent indexOutOfRange
        if(colorStepNumber >= depthColors.Length)
        {
            colorStepNumber = depthColors.Length - 1;
        }

        //set color of both components
        arrowTopImage.color = depthColors[colorStepNumber];
        arrowBottomImage.color = depthColors[colorStepNumber];
    }
}
