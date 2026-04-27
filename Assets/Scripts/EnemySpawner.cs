using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public static float spawnInterval = 2f;
    [SerializeField] public Vector2 spawnrange = new Vector2(10f, 10f);
    private int enemyCount = 0;
    private int maxEnemies = 10;
    private int totalEnemiesSpawned = 0;
    private int maxTotalEnemies = 50;

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }
    
    private IEnumerator spawnEnemies()
    {
    Vector2 position2D;
       while (enemyCount <maxEnemies && totalEnemiesSpawned < maxTotalEnemies)
        {
        position2D = new Vector2(transform.position.x, transform.position.y);
        Instantiate(enemyPrefab, position2D + Random.insideUnitCircle * spawnrange, Quaternion.identity);
        yield return new WaitForSeconds(spawnInterval);
        enemyCount++;
        totalEnemiesSpawned++;
        
        }
    }
}
