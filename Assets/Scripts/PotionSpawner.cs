using UnityEngine;
using System.Collections;
using TMPro;

public class PotionSpawner : MonoBehaviour
{
    public GameObject[] potionPrefabs; // Array of potion prefabs to spawn
    public Transform spawnArea; // Spawn area boundaries
    public float spawnHeight = 4f; // Height at which potions spawn
    public float spawnInterval = 0.5f; // Time interval between potion spawns
    public float spawnDuration = 3f; // Duration for which potions will spawn
    public float spawnCooldown = 10f; // Cooldown period after spawn duration

    public TextMeshProUGUI countdownText; // UI text for displaying countdown

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnPotionsRoutine());
    }

    IEnumerator SpawnPotionsRoutine()
    {
        Debug.Log("SpawnPotionsRoutine started");

        while (true)
        {
            // Check if spawning is allowed
            if (canSpawn)
            {
                // Start countdown for spawn duration
                for (float timer = spawnDuration; timer > 0; timer -= 1f)
                {
                    countdownText.text = "Potions spawning in " + Mathf.CeilToInt(timer) + "s";
                    yield return new WaitForSeconds(1f);
                }

                // Spawn potions for spawnDuration
                Debug.Log("Spawning potions...");
                countdownText.text = "";

                // Spawn potions for spawnDuration
                for (float timer = 0; timer < spawnDuration; timer += spawnInterval)
                {
                    SpawnPotion();
                    yield return new WaitForSeconds(spawnInterval);
                }

                // Set canSpawn to false and wait for spawnCooldown
                canSpawn = false;
                countdownText.text = "Potion spawn cooldown";
                Debug.Log("Spawn cooldown started");
                yield return new WaitForSeconds(spawnCooldown);
                canSpawn = true;
                countdownText.text = "";
                Debug.Log("Spawn cooldown ended");
            }
            else
            {
                Debug.Log("Waiting for spawn cooldown...");

                // Wait until canSpawn becomes true
                yield return null;
            }
        }
    }


    void SpawnPotion()
    {
        // Randomly select a potion prefab
        GameObject potionPrefab = potionPrefabs[Random.Range(0, potionPrefabs.Length)];

        // Randomly generate spawn position within spawnArea
        float spawnX = Random.Range(-12, 12);
        float spawnZ = Random.Range(-10, 5);
        Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, spawnZ);

        // Instantiate the potion prefab at the spawn position
        GameObject newPotion = Instantiate(potionPrefab, spawnPosition, Quaternion.identity);

        // Increase the size of spawned potion by 5 times
        newPotion.transform.localScale *= 5f;

        // Attach a script to the spawned potion for destruction after 2 seconds
        DestroyAfterDelay destroyScript = newPotion.GetComponent<DestroyAfterDelay>();
    }
}
