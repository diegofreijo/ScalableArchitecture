using System;
using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 1f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Rect spawnArea;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            var position = new Vector2(
                UnityEngine.Random.Range(spawnArea.xMin, spawnArea.xMax),
                UnityEngine.Random.Range(spawnArea.yMin, spawnArea.yMax)
            );

            Instantiate(enemyPrefab, position, Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(spawnArea.center, spawnArea.size);
    }
}
