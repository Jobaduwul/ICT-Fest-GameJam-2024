using TMPro;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public int breadCount = 0;
    public int tomatoCount = 0;
    public int steakCount = 0;
    public int mushroomCount = 0;
    public int burgerCount = 0;

    public int ragePotionCount = 0;
    public int freezePotionCount = 0;
    public int paralysePotionCount = 0;

    public TextMeshProUGUI ragePotionText;
    public TextMeshProUGUI freezePotionText;
    public TextMeshProUGUI paralysePotionText;

    public TextMeshProUGUI breadCountText;
    public TextMeshProUGUI tomatoCountText;
    public TextMeshProUGUI steakCountText;
    public TextMeshProUGUI mushroomCountText;
    public TextMeshProUGUI burgerCountText;

    public SoundManager soundManager; // Reference to the SoundManager script

    private bool isCollidingWithStove = false; // Flag to track stove collision
    public TextMeshProUGUI stovePromptText; // Reference to the TextMeshPro Text element for stove prompt

    private void Awake()
    {
        UpdatePotionText();
        burgerCountText.text = burgerCount.ToString("0");
        breadCountText.text = breadCount.ToString("0");
        tomatoCountText.text = tomatoCount.ToString("0");
        steakCountText.text = steakCount.ToString("0");
        mushroomCountText.text = mushroomCount.ToString("0");
    }
    void OnCollisionEnter(Collision collision)
    {
        string collidedPrefabName = collision.gameObject.name;

        if (collidedPrefabName.Contains("Bread"))
        {
            breadCount++;
            breadCountText.text = breadCount.ToString();
            soundManager.PlayCollectSound();
            //Debug.Log("Player collected Bread. Count: " + breadCount);
        }
        else if (collidedPrefabName.Contains("Tomato"))
        {
            tomatoCount++;
            tomatoCountText.text = tomatoCount.ToString();
            soundManager.PlayCollectSound();
            //Debug.Log("Player collected Tomato. Count: " + tomatoCount);
        }
        else if (collidedPrefabName.Contains("Steak"))
        {
            steakCount++;
            steakCountText.text=steakCount.ToString();
            soundManager.PlayCollectSound();
            //Debug.Log("Player collected Steak. Count: " + steakCount);
        }
        else if (collidedPrefabName.Contains("Mushroom"))
        {
            mushroomCount++;
            mushroomCountText.text=mushroomCount.ToString();
            soundManager.PlayCollectSound();
            //Debug.Log("Player collected Mushroom. Count: " + mushroomCount);
        }
        else if (collision.gameObject.CompareTag("Stove"))
        {
            isCollidingWithStove = true; // Set flag to true when colliding with a stove
            ShowStovePrompt();
        }

        if (collidedPrefabName.Contains("RagePotion"))
        {
            // Increment rage potion count
            ragePotionCount++;

            // Destroy the collided potion
            Destroy(collision.gameObject);

            // Update UI text
            UpdatePotionText();

            // Play sound effect for potion collection
            soundManager.PlayPotionSound();
        }
        else if (collidedPrefabName.Contains("FreezePotion"))
        {
            // Increment freeze potion count
            freezePotionCount++;

            // Destroy the collided potion
            Destroy(collision.gameObject);

            // Update UI text
            UpdatePotionText();

            // Play sound effect for potion collection
            soundManager.PlayPotionSound();
        }
        else if (collidedPrefabName.Contains("ParalysePotion"))
        {
            // Increment paralyse potion count
            paralysePotionCount++;

            // Destroy the collided potion
            Destroy(collision.gameObject);

            // Update UI text
            UpdatePotionText();

            // Play sound effect for potion collection
            soundManager.PlayPotionSound();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stove"))
        {
            isCollidingWithStove = false; // Set flag to false when exiting stove collision
            HideStovePrompt();
        }
    }

    void ShowStovePrompt()
    {
        if (stovePromptText != null)
        {
            stovePromptText.gameObject.SetActive(true);
            stovePromptText.text = "Press E to cook";
        }
    }

    void HideStovePrompt()
    {
        burgerCountText.text = burgerCount.ToString("0");
        if (stovePromptText != null)
        {
            stovePromptText.gameObject.SetActive(false);
        }
    }

    public void UpdatePotionText()
    {
        // Update UI text for rage potion count
        ragePotionText.text = ragePotionCount.ToString();

        // Update UI text for freeze potion count
        freezePotionText.text = freezePotionCount.ToString();

        // Update UI text for paralyse potion count
        paralysePotionText.text = paralysePotionCount.ToString();
    }

    void Update()
    {
        // Check if player is colliding with a stove and meets burger preparation conditions
        if (isCollidingWithStove && Input.GetKeyDown(KeyCode.E) && CanPrepareBurger())
        {
            PrepareBurger();
        }
    }

    bool CanPrepareBurger()
    {
        return breadCount >= 1 && tomatoCount >= 1 && steakCount >= 1 && mushroomCount >= 1;
    }

    void PrepareBurger()
    {
        burgerCount++;
        burgerCountText.text = burgerCount.ToString();
        Debug.Log("Burger prepared. Count: " + burgerCount);

        // Decrement the counts of bread, tomato, steak, and mushroom
        breadCount--;
        tomatoCount--;
        steakCount--;
        mushroomCount--;

        breadCountText.text = breadCount.ToString();
        tomatoCountText.text = tomatoCount.ToString();
        steakCountText.text = steakCount.ToString();
        mushroomCountText.text = mushroomCount.ToString();

        // Ensure the counts don't go below zero
        breadCount = Mathf.Max(breadCount, 0);
        tomatoCount = Mathf.Max(tomatoCount, 0);
        steakCount = Mathf.Max(steakCount, 0);
        mushroomCount = Mathf.Max(mushroomCount, 0);

        soundManager.PlayBurgerPrepareSound();
    }
}
