using UnityEngine;

public class RagePotionEffect : MonoBehaviour
{
    public float rageDuration = 10f;
    public float newWalkSpeed = 20f;
    public float newRunSpeed = 40f;

    private float originalWalkSpeed;
    private float originalRunSpeed;
    private bool isEffectActive = false;

    void Start()
    {
        // Store the original walk and run speeds
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            originalWalkSpeed = playerMovement.walkSpeed;
            originalRunSpeed = playerMovement.runSpeed;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && CanUseRagePotion() && !isEffectActive)
        {
            ActivateRageEffect();
        }
    }

    bool CanUseRagePotion()
    {
        // Check if rage potion count is greater than 0
        PlayerCollision playerCollision = GetComponent<PlayerCollision>();
        if (playerCollision != null)
        {
            return playerCollision.ragePotionCount > 0;
        }
        return false;
    }

    public void ActivateRageEffect()
    {
        // Set the rage effect as active
        isEffectActive = true;

        // Set the new walk and run speeds
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.walkSpeed = newWalkSpeed;
            playerMovement.runSpeed = newRunSpeed;
        }

        // Decrement rage potion count
        PlayerCollision playerCollision = GetComponent<PlayerCollision>();
        if (playerCollision != null)
        {
            playerCollision.ragePotionCount--;
            if (playerCollision.ragePotionCount < 0)
            {
                playerCollision.ragePotionCount = 0;
            }
            playerCollision.UpdatePotionText();
        }

        // Revert the effect after the specified duration
        Invoke("RevertRageEffect", rageDuration);
    }

    void RevertRageEffect()
    {
        // Revert to original walk and run speeds
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.walkSpeed = originalWalkSpeed;
            playerMovement.runSpeed = originalRunSpeed;
        }

        // Set the rage effect as inactive
        isEffectActive = false;
    }
}
