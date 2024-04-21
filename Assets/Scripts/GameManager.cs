using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject bossObject;
    public int bossHealth;
    public int stoveCount;

    public Text gameOverText;
    public Text victoryText;

    private bool isGameOver = false;
    private bool isVictory = false;

    void Start()
    {
        UpdateBossHealthUI();
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }

    public void BurgerHitBoss()
    {
        if (!isGameOver && !isVictory)
        {
            bossHealth--;
            UpdateBossHealthUI();

            if (bossHealth <= 0)
            {
                isVictory = true;
                HandleVictory();
            }
        }
    }

    public void StoveDestroyed()
    {
        if (!isGameOver && !isVictory)
        {
            stoveCount--;

            if (stoveCount <= 0 && GetComponent<PlayerCollision>().burgerCount <= 0 && bossHealth > 0)
            {
                isGameOver = true;
                HandleGameOver();
            }
        }
    }

    void UpdateBossHealthUI()
    {
        // Update UI to display current boss health
        Debug.Log("Boss Health: " + bossHealth);
    }

    void HandleGameOver()
    {
        Debug.Log("Game Over!");
        gameOverText.gameObject.SetActive(true);
    }

    void HandleVictory()
    {
        Debug.Log("Victory!");
        victoryText.gameObject.SetActive(true);
        Destroy(bossObject); // Destroy the boss object
    }
}