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

    public LevelSelectMenu _levelSelectMenu;

    public TMPro.TextMeshProUGUI courseDisplay;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        turnAllOff();
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /// <summary>
    /// Turns off all courses
    /// </summary>
    void turnAllOff()
    {
        foreach(Course c in courses)
        {
            c.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Turns off all courses and turns off timer
    /// </summary>
    public void FreeSail()
    {
        //turn off every course
        turnAllOff();

        //update the HUD text
        courseDisplay.text = "Free Sail";

        //turn off the timer if it's on
        if(timer.activeSelf)
        {
            timer.SetActive(false);
        }

        //turn off the menu
        if (_levelSelectMenu.menuMaximized)
        {
            _levelSelectMenu.ToggleMenu();
        }
    }

    /// <summary>
    /// Turns off all courses EXCEPT the selected course; moves the boat to the start point of the selected course
    /// </summary>
    /// <param name="courseNumber">The course to be started (0-based)</param>
    public void activateCourse(int courseNumber)
    {
        //turn off all courses
        turnAllOff();

        //if the timer's not already visible, turn it on
        if(!timer.activeSelf)
        {
            timer.SetActive(true);
        }

        //turn on the selected course
        courses[courseNumber].gameObject.SetActive(true);

        //update the HUD
        courseDisplay.text = "Course " + (courseNumber + 1);

        //move the boat
        playerBoat.transform.position = new Vector3(courses[courseNumber].startPoint.position.x, playerBoat.transform.position.y, courses[courseNumber].startPoint.position.z);
        playerBoat.transform.rotation = courses[courseNumber].startPoint.rotation;

        //shut off the menu
        if (_levelSelectMenu.menuMaximized)
        {
            _levelSelectMenu.ToggleMenu();
        }
       
    }



}
