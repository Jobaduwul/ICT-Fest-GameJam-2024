using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    // Define a delegate signature for food destruction notification
    public delegate void FoodDestroyed(GameObject foodObject);
    public static event FoodDestroyed OnFoodDestroyed;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Stove" or "Player"
        if (collision.gameObject.CompareTag("Stove") || collision.gameObject.CompareTag("Player"))
        {
            // Notify the SpawnManager that this food object is destroyed
            if (OnFoodDestroyed != null)
            {
                OnFoodDestroyed(gameObject);
            }

            // Destroy the food object
            Destroy(gameObject);
        }
    }
}
