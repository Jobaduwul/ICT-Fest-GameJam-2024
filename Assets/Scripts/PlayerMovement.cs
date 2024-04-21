using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public new Camera camera;

    [Header("Configurations")]
    public float walkSpeed = 5f; 
    public float runSpeed = 10f; 

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!PauseMenu.Paused)
        {
            // Horizontal Rotation
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);       // multiplier present
        }
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;           // new Vector3(0f, rb.velocity.y, 0f)

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = transform.TransformDirection(newVelocity);
    }

    void LateUpdate()
    {
        if (!PauseMenu.Paused) 
        {
            // Vertical Rotation
            Vector3 verticalRotator = head.eulerAngles;
            verticalRotator.x -= Input.GetAxis("Mouse Y") * 2f;                   //  Edit the multiplier to adjust the rotate speed
            verticalRotator.x = RestrictAngle(verticalRotator.x, -65f, 65f);    //  This is clamped to 65 degrees
            head.eulerAngles = verticalRotator;
        }
    }


    //  Clamp the vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}
