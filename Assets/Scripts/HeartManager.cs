using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
<<<<<<< HEAD
        slider.value = health;
=======
        // Check if stove health script is assigned and update hearts accordingly
        if (stoveHealthScript != null)
        {
            stoveHealth = stoveHealthScript.currentLives;
            UpdateHearts();
        }
        //Debug.Log("In heart manager:" + stoveHealth);
        //by default everything is empty heart
        //foreach (GameObject heart in hearts)
        //{
        //    heart.GetComponent<SpriteRenderer>().sprite = redHeart.GetComponent<SpriteRenderer>().sprite;
        //}

        //percentage = ((float)stoveHealth / maxStoveHealth) * 100.0f;

        //temporarily commenting this to show some other stats
        //Debug.Log("Health: " + percentage);

        //according to health, the full hearts are being filled


    }

    void UpdateHearts()
    {
        // Display hearts based on stove health
        if (stoveHealth == 3)
        {
            // Display all three hearts
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (stoveHealth == 2)
        {
            // Display two hearts
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (stoveHealth == 1)
        {
            // Display one heart
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else
        {
            // Display zero heart
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
>>>>>>> ed69dfcbdbfe81fbb70086f2db15f8a0fbc692e8
    }
}