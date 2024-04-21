using UnityEngine;

public class StoveHealth : MonoBehaviour
{
    public int maxLives; // Maximum number of lives for the stove
    private int currentLives; // Current number of lives for the stove

    void Start()
    {
        currentLives = maxLives; // Initialize current lives to max lives
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            // Decrement stove's current lives
            currentLives--;
            HeartManager.stoveCount--;

            Debug.Log("Stove hit by food. Current lives: " + currentLives);

            // Check if stove's lives reach 0
            if (currentLives <= 0)
            {
                // Destroy the stove object
                Debug.Log("Stove destroyed.");
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
