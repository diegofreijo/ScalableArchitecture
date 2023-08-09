using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootInterval = 1;

    void Start()
    {
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            var bulletGo = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            var bulletRb = bulletGo.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.one * 3;
        }
    }
}
