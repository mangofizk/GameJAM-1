using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public static float spawnInterval = 2.5f;
    [SerializeField] private Vector2 spawnRange = new Vector2(10f, 10f);
    private int[] waves = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 8 };

    public static ObjectPool<GameObject> enemyPool;

    void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(
            createFunc: () => {
                GameObject e = Instantiate(enemyPrefab);
                e.SetActive(false);
                return e;
            },
            actionOnGet: e => e.SetActive(true),
            actionOnRelease: e => e.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 100
        );
    }

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }


    private IEnumerator spawnEnemies()
    {
        Vector2 position2D;
        for (int i = 0; i < waves.Length; i++)
        {
            position2D = new Vector2(transform.position.x, transform.position.y);
            for (int e = 0; e < waves[i]; e++)
            {
                GameObject enemy = enemyPool.Get();
                enemy.transform.position = position2D + Random.insideUnitCircle * spawnRange;
                enemy.transform.rotation = Quaternion.identity;
            }
            yield return new WaitForSeconds(spawnInterval);
        }

    }
    void OnDestroy()
    {
        enemyPool?.Dispose();
    }
}