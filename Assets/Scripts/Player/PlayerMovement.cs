using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public KeyCode Up, Down, Left, Right;

    public float speed;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        KeyboardMove();
    }

    private void Update()
    {
        if (Input.GetKey(Right))
        {
            direction.x += 1;
        }
        if (Input.GetKey(Left))
        {
            direction.x -= 1;
        }
        if (Input.GetKey(Up))
        {
            direction.y += 1;
        }
        if (Input.GetKey(Down))
        {
            direction.y -= 1;
        }
    }

    private void KeyboardMove()
    {
        Vector2 currentPosition = transform.position;
        direction *= Time.fixedDeltaTime * speed;
        rb.MovePosition(currentPosition + direction);
    }
}
