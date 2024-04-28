using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array of food prefabs to spawn
    public float spawnInterval; // Time interval between spawns
    public Vector3 spawnRangeMin; // Minimum spawn position
    public Vector3 spawnRangeMax; // Maximum spawn position
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

        // Find the boss object
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");

        // Get the x-coordinate of the boss
        float bossX = boss.transform.position.x;

        if(boss != null)
        {
            // Generate a random spawn position within the specified range
            Vector3 spawnPosition = new Vector3(bossX,
                                                Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                                                Random.Range(spawnRangeMin.z, spawnRangeMax.z));

            // Spawn the food item at the random spawn position
            GameObject newFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);

            // Enlarge the spawned food item by 5 times
            newFood.transform.localScale *= 5f;

            // Add colliders to the spawned food item if they're not already present
            Collider foodCollider = newFood.GetComponent<Collider>();

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

    }

    void OnDestroy()
    {
        // Unsubscribe from the FoodCollision event when this object is destroyed
        FoodCollision.OnFoodDestroyed -= HandleFoodDestroyed;
    }

    void HandleFoodDestroyed(GameObject foodObject)
    {
        // Handle the destruction of the food object here (e.g., remove it from a list)
        //Debug.Log("Food destroyed: " + foodObject.name);
    }
}
