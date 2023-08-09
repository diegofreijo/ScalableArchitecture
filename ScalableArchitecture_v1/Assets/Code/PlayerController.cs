using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    public void OnMove(InputValue value)
    {
        rb.velocity = value.Get<Vector2>() * speed * Time.deltaTime;
    }
}
