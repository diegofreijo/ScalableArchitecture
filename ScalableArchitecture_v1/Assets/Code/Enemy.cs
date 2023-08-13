using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(40);
            Destroy(gameObject);
        }
    }
}
