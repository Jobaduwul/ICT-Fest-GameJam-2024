using UnityEngine;

public class StoveHealth : MonoBehaviour
{
    public int maxLives; // Maximum number of lives for the stove
    public int currentLives; // Current number of lives for the stove

    public HeartManager heartManager; 

    void Start()
    {
        currentLives = maxLives; // Initialize current lives to max lives
        heartManager.SetMaxHealth((int)maxLives);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            // Decrement stove's current lives
            currentLives--;
            heartManager.SetHealth((int)currentLives);

            Debug.Log("Stove hit by food. Current lives: " + currentLives);

            // Check if stove's lives reach 0
            if (currentLives <= 0)
            {
                // Destroy the stove object
                Debug.Log("Stove destroyed.");

                if (heartManager != null)
                {
                    Destroy(heartManager.gameObject);
                }

                Destroy(gameObject);

                // Notify GameManager that a stove is destroyed
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.StoveDestroyed(); // Notify GameManager that a stove is destroyed
                }
            }
        }
    }
}
