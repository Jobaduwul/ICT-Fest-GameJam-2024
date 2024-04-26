using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float radius = 2f;           // Radius of the circular path
    public float speed = 2f;            // Speed of movement along the path
    public bool clockwise = true;       // Direction of movement (clockwise or counterclockwise)

    private Vector3 center;             // Center point of the circle
    private float angle = 0f;           // Current angle along the circle

    void Start()
    {
        // Calculate the center point of the circle based on the initial position of the object
        center = transform.position;
    }

    void Update()
    {
        // Calculate the new position of the object along the circle
        float angleInRadians = angle * Mathf.Deg2Rad;
        float x = center.x + Mathf.Cos(angleInRadians) * radius;
        float z = center.z + Mathf.Sin(angleInRadians) * radius;

        // Set the object's position
        transform.position = new Vector3(x, transform.position.y, z);

        // Update the angle based on the direction of movement
        if (clockwise)
        {
            angle += speed * Time.deltaTime;
        }
        else
        {
            angle -= speed * Time.deltaTime;
        }

        // Ensure the angle stays within the range [0, 360)
        angle %= 360f;
    }
}
