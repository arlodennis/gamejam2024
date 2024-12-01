using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    public GameObject pauseScreen = null;
    
    void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // GameObject pauseScreen = GameObject.FindGameObjectsWithTag("pauseTab")[0];
            if (pauseScreen.activeSelf)
                {
                    pauseScreen.SetActive(false);
                }
            else{
                    pauseScreen.SetActive(true);
                }
        }
    }
}