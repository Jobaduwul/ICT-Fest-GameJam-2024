using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int stoveHealth = 3;
    public int maxStoveHealth = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject stove;
    private StoveHealth stoveHealthScript;
    //public GameObject redHeart;
    //public Sprite greenHeart;
    //public Sprite yellowHeart;
    //public Sprite emptyHeart;

    private double percentage;

    private void Awake()
    {
        stoveHealthScript = stove.GetComponent<StoveHealth>();
        if (stoveHealthScript != null)
        {
            maxStoveHealth = stoveHealthScript.maxLives; // Set maxStoveHealth
            UpdateHearts(); // Update hearts based on current health
        }
        else
        {
            Debug.LogError("StoveHealth script not found on stove object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}