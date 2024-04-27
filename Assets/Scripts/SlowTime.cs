using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [Header("TimeControllerSettings")]
    public float TimeScale;

    private float StartTimeScale;
    private float StartFixedDeltaTime;

    public static bool TimeSlowed = false;
    public GameObject ScrollMenuObject;



    void Start()
    {
        StartTimeScale = Time.timeScale;
        StartFixedDeltaTime = Time.fixedDeltaTime;
    }


    void Update()
    {
        if(!PauseMenu.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                StartSlowMotion();
            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                StopSlowMotion();
            }
        }
        
    }

    public void StartSlowMotion()
    {
        TimeSlowed = true;
        ScrollMenuObject.SetActive(true);

        Time.timeScale = TimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void StopSlowMotion()
    {
        Time.timeScale = StartTimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime;

        TimeSlowed = false;
        ScrollMenuObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}