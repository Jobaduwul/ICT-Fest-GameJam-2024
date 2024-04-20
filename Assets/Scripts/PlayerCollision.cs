using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int breadCount = 0;
    public int tomatoCount = 0;
    public int steakCount = 0;
    public int mushroomCount = 0;
    public int burgerCount = 0;

    private bool isCollidingWithStove = false; // Flag to track stove collision

    void OnCollisionEnter(Collision collision)
    {
        string collidedPrefabName = collision.gameObject.name;

        if (collidedPrefabName.Contains("Bread"))
        {
            breadCount++;
            Debug.Log("Player collected Bread. Count: " + breadCount);
        }
        else if (collidedPrefabName.Contains("Tomato"))
        {
            tomatoCount++;
            Debug.Log("Player collected Tomato. Count: " + tomatoCount);
        }
        else if (collidedPrefabName.Contains("Steak"))
        {
            steakCount++;
            Debug.Log("Player collected Steak. Count: " + steakCount);
        }
        else if (collidedPrefabName.Contains("Mushroom"))
        {
            mushroomCount++;
            Debug.Log("Player collected Mushroom. Count: " + mushroomCount);
        }
        else if (collision.gameObject.CompareTag("Stove"))
        {
            isCollidingWithStove = true; // Set flag to true when colliding with a stove
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stove"))
        {
            isCollidingWithStove = false; // Set flag to false when exiting stove collision
        }
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
