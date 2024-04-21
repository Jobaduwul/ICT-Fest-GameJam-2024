using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static int stoveCount = 5;
    public int maxStoveCount = 5;
    public Image[] hearts;
    public Sprite redHeart;
    public Sprite greenHeart;
    public Sprite yellowHeart;
    public Sprite emptyHeart;

    private double percentage;

    private void Awake()
    {
        stoveCount = maxStoveCount;
    }

    // Update is called once per frame
    void Update()
    {
        //by default everything is empty heart
        foreach (Image heart in hearts)
        {
            heart.sprite = emptyHeart;
        }

        percentage = ((float)stoveCount / maxStoveCount) * 100.0f;

        //temporarily commenting this to show some other stats
        //Debug.Log("Health: " + percentage);

        //according to health, the full hearts are being filled
        for (int i = 0; i < stoveCount; i++)
        {
            if (percentage < 40.0f && percentage > 0f)
            {
                hearts[i].sprite = redHeart;
            }
            else if (percentage < 75.0f)
            {
                hearts[i].sprite = yellowHeart;
            }
            else
            {
                hearts[i].sprite = greenHeart;
            }

        }
    }
}