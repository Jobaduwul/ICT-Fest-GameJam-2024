using Unity.VisualScripting;
using UnityEngine;

public class ParalysePotionEffect : MonoBehaviour
{
    public float paralyseDuration = 10f;

    private BossMovement bossMovement;
    private SpawnManager spawnManager;

    void Start()
    {
        // Find the Boss object and get its BossMovement component
        GameObject bossObject = GameObject.FindGameObjectWithTag("Boss");
        if (bossObject != null)
        {
            bossMovement = bossObject.GetComponent<BossMovement>();
        }

        // Find the SpawnManager object and get its SpawnManager component
        GameObject spawnManagerObject = GameObject.FindGameObjectWithTag("SpawnManager");
        if (spawnManagerObject != null)
        {
            spawnManager = spawnManagerObject.GetComponent<SpawnManager>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && CanUseParalysePotion()) // Check potion count before use
        {
            ActivateParalyseEffect();
        }
    }

    public bool CanUseParalysePotion()
    {
        // Find the Player object and get its PlayerCollision component
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            PlayerCollision playerCollision = playerObject.GetComponent<PlayerCollision>();
            if (playerCollision != null)
            {
                // Check if paralysePotionCount is greater than or equal to 1
                return playerCollision.paralysePotionCount >= 1;
            }
        }

        // Allow using the potion if player object or component is not found (assuming starting value is 0 or greater)
        return true;
    }

    public void ActivateParalyseEffect()
    {
        // Disable BossMovement script for the boss object
        if (bossMovement != null)
        {
            bossMovement.enabled = false;
            Invoke("EnableBossMovement", paralyseDuration);
        }

        // Disable SpawnManager script for the spawn manager object
        if (spawnManager != null)
        {
            spawnManager.enabled = false;
            Invoke("EnableSpawnManager", paralyseDuration);
        }

        // Decrement paralyse potion count (only if potion count is valid)
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            PlayerCollision playerCollision = playerObject.GetComponent<PlayerCollision>();
            if (playerCollision != null)
            {
                playerCollision.paralysePotionCount--;
                playerCollision.UpdatePotionText();
            }
        }
    }

    void EnableBossMovement()
    {
        // Re-enable BossMovement script for the boss object
        if (bossMovement != null)
        {
            bossMovement.enabled = true;
        }
    }

    void EnableSpawnManager()
    {
        // Re-enable SpawnManager script for the spawn manager object
        if (spawnManager != null)
        {
            spawnManager.enabled = true;
        }
    }
}
