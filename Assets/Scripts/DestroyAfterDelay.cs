using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay;

    void Start()
    {
        // Destroy the game object after the specified delay
        Destroy(gameObject, delay);
    }
}