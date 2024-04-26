using TMPro;
using UnityEngine;
using Unity.UI;

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

    public TextMeshProUGUI burgerCountText;

    private bool isCollidingWithStove = false; // Flag to track stove collision
    public TextMeshProUGUI stovePromptText; // Reference to the TextMeshPro Text element for stove prompt

    private void Awake()
    {
        UpdatePotionText();
        burgerCountText.text = burgerCount.ToString("0");
    }
    void OnCollisionEnter(Collision collision)
    {
        string collidedPrefabName = collision.gameObject.name;

        if (collidedPrefabName.Contains("Bread"))
        {
            breadCount++;
            //Debug.Log("Player collected Bread. Count: " + breadCount);
        }
        else if (collidedPrefabName.Contains("Tomato"))
        {
            tomatoCount++;
            //Debug.Log("Player collected Tomato. Count: " + tomatoCount);
        }
        else if (collidedPrefabName.Contains("Steak"))
        {
            steakCount++;
            //Debug.Log("Player collected Steak. Count: " + steakCount);
        }
        else if (collidedPrefabName.Contains("Mushroom"))
        {
            mushroomCount++;
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
        }
        else if (collidedPrefabName.Contains("FreezePotion"))
        {
            // Increment freeze potion count
            freezePotionCount++;

            // Destroy the collided potion
            Destroy(collision.gameObject);

            // Update UI text
            UpdatePotionText();
        }
        else if (collidedPrefabName.Contains("ParalysePotion"))
        {
            // Increment paralyse potion count
            paralysePotionCount++;

            // Destroy the collided potion
            Destroy(collision.gameObject);

            // Update UI text
            UpdatePotionText();
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

        // Ensure the counts don't go below zero
        breadCount = Mathf.Max(breadCount, 0);
        tomatoCount = Mathf.Max(tomatoCount, 0);
        steakCount = Mathf.Max(steakCount, 0);
        mushroomCount = Mathf.Max(mushroomCount, 0);
    }
}
