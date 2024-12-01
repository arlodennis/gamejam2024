using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("code escape pressed");
            screen = GameObject.FindGameObjectsWithTag("pauseTab");
            if (screen.activeSelf)
                {
                    screen.SetActive(false);
                }
            else{
                    screen.SetActive(true);
                }
        }
    }
}