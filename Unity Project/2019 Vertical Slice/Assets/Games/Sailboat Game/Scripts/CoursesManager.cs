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

    void turnAllOff()
    {
        foreach(Course c in courses)
        {
            c.gameObject.SetActive(false);
        }
    }

    public void FreeSail()
    {
        turnAllOff();
        courseDisplay.text = "Free Sail";
        if(timer.activeSelf)
        {
            timer.SetActive(false);
        }
        if (_levelSelectMenu.menuMaximized)
        {
            _levelSelectMenu.ToggleMenu();
        }
    }

    public void activateCourse(int courseNumber)
    {

        turnAllOff();
        if(!timer.activeSelf)
        {
            timer.SetActive(true);
        }
        courses[courseNumber].gameObject.SetActive(true);
        courseDisplay.text = "Course " + (courseNumber + 1);
        playerBoat.transform.position = new Vector3(courses[courseNumber].startPoint.position.x, playerBoat.transform.position.y, courses[courseNumber].startPoint.position.z);
        playerBoat.transform.rotation = courses[courseNumber].startPoint.rotation;
        if (_levelSelectMenu.menuMaximized)
        {
            _levelSelectMenu.ToggleMenu();
        }
       // StartCoroutine(moveBoat(new Vector3(courses[courseNumber].startPoint.position.x, playerBoat.transform.position.y, courses[courseNumber].startPoint.position.z), courseNumber + 1));
    }



}
