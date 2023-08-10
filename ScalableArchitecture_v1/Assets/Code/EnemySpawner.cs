using System;
using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 1f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Rect spawnArea;

    private int nextId = 1;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (true)
        {
            var position = new Vector2(
                UnityEngine.Random.Range(spawnArea.xMin, spawnArea.xMax),
                UnityEngine.Random.Range(spawnArea.yMin, spawnArea.yMax)
            );

            var go = Instantiate(enemyPrefab, position, Quaternion.identity, transform);

            go.name += nextId;
            nextId++;

            yield return new WaitForSeconds(interval);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(spawnArea.center, spawnArea.size);
    }
}
