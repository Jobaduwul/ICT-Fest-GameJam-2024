using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float rotationSpeed = 10f; // Speed of rotation

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on the input
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Rotate the player to face the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.TransformDirection(movement), Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // Move the player forward based on the input
        if (movement.z > 0)
        {
            rb.MovePosition(rb.position + transform.forward * movement.magnitude * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
