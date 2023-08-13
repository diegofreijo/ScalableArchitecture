using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<Destructable>(out var _))
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
