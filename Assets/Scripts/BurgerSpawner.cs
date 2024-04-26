using TMPro;
using UnityEngine;

public class BurgerSpawner : MonoBehaviour
{
    public GameObject burgerPrefab;
    public float burgerSpeed;
    public float burgerSizeMultiplier = 5f;

    void Update()
    {
        if ( !PauseMenu.Paused )
        {
            // Check if left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Check if burger count is at least 1
                if (GetComponent<PlayerCollision>().burgerCount >= 1)
                {
                    SpawnBurger();
                }
            }
        }
    }

    void SpawnBurger()
    {
        // Spawn burger prefab just in front of player location
        Vector3 spawnPosition = new Vector3(transform.position.x, 2.5f, transform.position.z) + transform.forward * 2f;
        GameObject burger = Instantiate(burgerPrefab, spawnPosition, Quaternion.identity);

        // Increase size of burger
        burger.transform.localScale *= burgerSizeMultiplier;

        // Get the burger's Rigidbody component and set its velocity to move forwards
        Rigidbody burgerRigidbody = burger.GetComponent<Rigidbody>();
        if (burgerRigidbody != null)
        {
            burgerRigidbody.velocity = transform.forward * burgerSpeed;
        }

        // Decrement burger count
        GetComponent<PlayerCollision>().burgerCount--;
        GetComponent<PlayerCollision>().burgerCountText.text = GetComponent<PlayerCollision>().burgerCount.ToString();
    }
}
