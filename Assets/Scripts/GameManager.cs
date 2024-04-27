using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject bossObject;
    public int bossHealth = 3;
    public int stoveCount;

    public TextMeshProUGUI stoveCountText;
    //public TextMeshProUGUI gameOverText;
    //public TextMeshProUGUI victoryText;

    //private int bossHealth;
    private bool isGameOver = false;
    private bool isVictory = false;

    void Start()
    {
        UpdateBossHealthUI();
        //gameOverText.gameObject.SetActive(false);
        //victoryText.gameObject.SetActive(false);
        stoveCountText.text = stoveCount.ToString();
    }

    void UpdateBossHealthUI()
    {
        // Update UI to display current boss health
        Debug.Log("Boss Health: " + bossHealth);
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
            stoveCountText.text = stoveCount.ToString();

            if (stoveCount <= 0 && FindObjectOfType<Burger>() == null && bossHealth > 0)
            {
                isGameOver = true;
                HandleGameOver();
            }
        }
    }

    void HandleGameOver()
    {
        Debug.Log("Game Over!");
        //gameOverText.gameObject.SetActive(true);
    }

    void HandleVictory()
    {
        Debug.Log("Victory!");
        //victoryText.gameObject.SetActive(true);
        Destroy(bossObject); // Destroy the boss object
    }
}
