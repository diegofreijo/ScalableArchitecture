using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int speed = 300;
    // [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 movement = Vector2.zero;

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0)
            transform.localScale = movement.x < 0 ? new Vector3(-1, 1, 1) : Vector3.one;
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * Time.deltaTime * movement;
    }
}
