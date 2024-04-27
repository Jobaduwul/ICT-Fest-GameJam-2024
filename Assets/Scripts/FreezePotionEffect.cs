using UnityEngine;

public class FreezePotionEffect : MonoBehaviour
{
    public float freezeDuration = 10f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActivateFreezeEffect();
        }
    }

    public void ActivateFreezeEffect()
    {
        // Disable circular motion script on this stove
        CircularMovement circularMotion = GetComponent<CircularMovement>();
        if (circularMotion != null)
        {
            circularMotion.enabled = false;
            Invoke("EnableCircularMotion", freezeDuration);
        }

        // Freeze all position and rotation axes
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("UnfreezePosition", freezeDuration);
        }

        // Decrement freeze potion count
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            PlayerCollision playerCollision = playerObject.GetComponent<PlayerCollision>();
            if (playerCollision != null)
            {
                playerCollision.freezePotionCount--;
                if (playerCollision.freezePotionCount < 0)
                {
                    playerCollision.freezePotionCount = 0;
                }
                playerCollision.UpdatePotionText();
            }
        }
    }



    void EnableCircularMotion()
    {
        // Re-enable circular motion script on this stove
        CircularMovement circularMotion = GetComponent<CircularMovement>();
        if (circularMotion != null)
        {
            circularMotion.enabled = true;
        }
    }

    void UnfreezePosition()
    {
        // Freeze only y position and all rotations
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            // Reset the position to the original y-axis position
            transform.position = new Vector3(transform.position.x, originalPosition.y, transform.position.z);
        }
    }
}
