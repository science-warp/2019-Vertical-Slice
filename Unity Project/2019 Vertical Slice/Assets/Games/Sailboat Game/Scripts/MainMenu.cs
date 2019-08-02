using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{


    public int mainSceneIndex;
    public int optionsSceneIndex;


    public void playGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneIndex);
    }

    public void openOptions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(optionsSceneIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
