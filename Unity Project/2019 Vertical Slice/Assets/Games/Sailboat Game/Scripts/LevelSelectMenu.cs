using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelSelectMenu : MonoBehaviour
{
    [Tooltip("The X position of the menu's transform when it is minimized to the side of the screen.")]
    public float minimizedX;
   // [Tooltip("The X and Y positions of the menu's transform when it is minimized to the side of the screen.")]
   // public float minimizedY;

    [Tooltip("The X position of the menu's transform when it is maximized and in use.")]
    public float maximizedX;
  //  [Tooltip("The X and Y positions of the menu's transform when it is maximized and in use.")]
    //public float maximizedY;

    public bool menuMaximized = false;

    [Tooltip("Number of seconds it takes to minimize the menu.")]
    public float minTime = .6f;

    [Tooltip("Number of seconds it takes to maximize the menu.")]
    public float maxTime = 1.6f;

    RectTransform thisRect;

    public AnimationCurve entranceCurve;

    // Start is called before the first frame update
    void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMenu()
    {

        if (menuMaximized)//PUT IT BAAACK
        {
            thisRect.DOAnchorPosX(minimizedX, minTime).SetEase(Ease.InOutSine);
        }
        else //pull it out
        {
            thisRect.DOAnchorPosX(maximizedX, maxTime).SetEase(entranceCurve);
        }

        //set the toggle bool 
        menuMaximized = !menuMaximized;
    }
}
