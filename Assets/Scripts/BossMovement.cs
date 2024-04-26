using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public bool moveRight;
    public float timer, timerBetweenSwitches;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = timerBetweenSwitches;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if(moveRight == true)
        {
            if(timer>0)
            {
                // transform.Translate(Vector3.right * Time.deltaTime * speed);
                rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);
            }

            else
            {
                moveRight = false;
                timer = timerBetweenSwitches;
            }
        }

        if (moveRight == false)
        {
            if (timer > 0)
            {
                // transform.Translate(Vector3.left * Time.deltaTime * speed);
                rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * speed);
            }

            else
            {
                moveRight = true;
                timer = timerBetweenSwitches;
            }
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

    }
}
