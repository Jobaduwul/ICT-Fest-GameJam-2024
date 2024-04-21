using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuObject;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }

            else
            {
                Stop();
            }
        }
    }


    public void Stop()
    {
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        PauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuButton()
    {
        Paused = false;
        SceneManager.LoadScene(0);
    }

}
