using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    // [SerializeField] private float shootInterval = 1;
    [SerializeField] private float bulletSpeed = 10;

    private readonly List<Transform> enemiesOnRange = new();
    private Vector2 lookingAt = Vector2.zero;

    public void OnLook(InputValue value)
    {
        lookingAt = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    public void OnFire()
    {
        FireAt(lookingAt);
    }

    // private IEnumerator StartShooting()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(shootInterval);
    //         if (enemiesOnRange.Count > 0)
    //             FireAt(enemiesOnRange[0].position);
    //     }
    // }

    private void FireAt(Vector2 target)
    {
        var bulletGo = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletGo.transform.LookAt(Vector3.forward, target);

        Vector2 direction = (target - (Vector2)transform.position).normalized;
        // Debug.Log($"Direction {direction}");
        float bulletAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletGo.transform.eulerAngles = new Vector3(0, 0, bulletAngle);

        var bulletRb = bulletGo.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed;

        Destroy(bulletGo, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"Adding {other.name}");
        enemiesOnRange.Add(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log($"Removing {other.name}");
        enemiesOnRange.Remove(other.transform);
    }
}
