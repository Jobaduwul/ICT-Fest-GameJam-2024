using UnityEngine;

public class Burger : MonoBehaviour
{
    public float destroyThresholdZ = 35; // Z-coordinate threshold for destruction

    void Update()
    {
        // Check if the burger's Z-coordinate exceeds the destroy threshold
        if (transform.position.z > destroyThresholdZ)
        {
            Destroy(gameObject); // Destroy the burger if it goes beyond the threshold
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.BurgerHitBoss(); // Notify GameManager that a burger hit the boss
            }
            Destroy(gameObject); // Destroy the burger if collided with the boss
        }
        else if (collision.gameObject.CompareTag("Stove") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy the burger if it collides with a stove or wall
        }
    }
}
