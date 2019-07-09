﻿using System.Collections;
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

    public TMPro.TextMeshProUGUI depthText;

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


    // Start is called before the first frame update
    void Start()
    {
        setDepth(maxDepth);

        //calculate step sizes;

        topScaleStepSize = (deepestArrowHeight - shallowestArrowHeight) / 100f;
        bottomPosStepSize = (deepestArrowPos - shallowestArrowPos) / 100f;
    }

    public void setDepth(float newMaxDepth)
    {
        maxDepth = newMaxDepth;

        colorStepSize = maxDepth / depthColors.Length;
    }

    //this should be called in the Update function of the boat
    public void updateDepth(float depth)
    {
        //calculate percentage
        currentDepthPercentage = depth / maxDepth * 100f;

        depthText.text = ((int)depth).ToString() + "ft";

        //now we handle sizing
        //set height of top portion
        arrowTop.localScale = (new Vector3(arrowTop.localScale.x, shallowestArrowHeight + (topScaleStepSize * currentDepthPercentage), arrowTop.localScale.z));
        arrowBottom.position = (new Vector3(arrowBottom.position.x, shallowestArrowPos + bottomPosStepSize * currentDepthPercentage, arrowBottom.position.z));

        //now we handle the color.
        //first determine which step.

        int colorStepNumber = (int)Mathf.Floor(depth / colorStepSize);

        arrowTopImage.color = depthColors[colorStepNumber];
        arrowBottomImage.color = depthColors[colorStepNumber];
    }
}
