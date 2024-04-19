using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array of food prefabs to spawn
    public float spawnInterval; // Time interval between spawns
    public Vector3 spawnRangeMin = new Vector3(-10f, 0.5f, 3f); // Minimum spawn position
    public Vector3 spawnRangeMax = new Vector3(10f, 0.5f, 3f); // Maximum spawn position
    public float moveSpeed; // Speed of movement in negative y-axis direction

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;

        // Subscribe to the FoodCollision event
        FoodCollision.OnFoodDestroyed += HandleFoodDestroyed;
    }

    void Update()
    {
        // Check if it's time to spawn a new food item
        if (Time.time >= nextSpawnTime)
        {
            SpawnFood();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnFood()
    {
        // Randomly select a food prefab from the array
        GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        // Generate a random spawn position within the specified range
        Vector3 spawnPosition = new Vector3(Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                                            Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                                            Random.Range(spawnRangeMin.z, spawnRangeMax.z));

        // Spawn the food item at the random spawn position
        GameObject newFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);

        // Ensure the spawned food item has a Rigidbody component
        Rigidbody foodRigidbody = newFood.GetComponent<Rigidbody>();
        if (foodRigidbody == null)
        {
            foodRigidbody = newFood.AddComponent<Rigidbody>();
        }

        foodRigidbody.useGravity = false;

        // Move the spawned food item in the negative y-axis direction
        foodRigidbody.velocity = Vector3.back * moveSpeed;
    }

    void OnDestroy()
    {
        // Unsubscribe from the FoodCollision event when this object is destroyed
        FoodCollision.OnFoodDestroyed -= HandleFoodDestroyed;
    }

    void HandleFoodDestroyed(GameObject foodObject)
    {
        // Handle the destruction of the food object here (e.g., remove it from a list)
        Debug.Log("Food destroyed: " + foodObject.name);
    }
}
