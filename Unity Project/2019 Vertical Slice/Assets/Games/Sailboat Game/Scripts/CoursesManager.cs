using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CoursesManager : MonoBehaviour
{

    public Course[] courses;

    public GameObject playerBoat;

    public float fadeTime = .2f;
    public float holdTime = .5f;


    public RawImage canvasCover;

    public TMPro.TextMeshProUGUI courseDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            activateCourse(0);
        }
    }

    public void activateCourse(int courseNumber)
    {
       
        StartCoroutine(moveBoat(new Vector3(courses[courseNumber].startPoint.position.x, playerBoat.transform.position.y, courses[courseNumber].startPoint.position.z), courseNumber + 1));
    }

    /// <summary>
    /// Moves the boat AFTER the UI fades a cover image in.
    /// </summary>
    /// <param name="secondsFadeUI">How long it should take the cover image to fade in, in seconds</param>
    /// <returns></returns>
    public IEnumerator moveBoat(Vector3 moveTo, int courseNum)
    {
        StartCoroutine(cameraFade(fadeTime, holdTime, canvasCover));
        yield return new WaitForSeconds(fadeTime);
        courseDisplay.text = "Course " + (courseNum);
        playerBoat.transform.position = moveTo;
    }


    /// <summary>
    /// Fades in a UI image, holds for specified seconds, and fades it back out.
    /// </summary>
    /// <param name="secondsFade"> How long the fades in and out should take.</param>
    /// <param name="seconds">Number of seconds that the image should be at full opacity</param>
    /// <param name="fadeTo"></param>
    /// <returns></returns>
    public IEnumerator cameraFade(float secondsFade, float secondsHold, RawImage fadeTo)
    {
        fadeTo.DOColor(Color.white, secondsFade);
        yield return new WaitForSeconds(secondsHold);
        fadeTo.DOColor(Color.clear, secondsFade);
    }

}
