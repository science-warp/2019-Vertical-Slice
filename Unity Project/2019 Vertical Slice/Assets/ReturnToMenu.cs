using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{

    public int mainMenuIndex = 0;


    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuIndex);
    }
}
