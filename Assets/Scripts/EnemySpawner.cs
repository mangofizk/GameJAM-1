using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public static float spawnInterval = 2.5f;
    [SerializeField] public Vector2 spawnrange = new Vector2(10f, 10f);

    private int[] waves = {1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 8};
    

    public EnemyPool EnemyPool;

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }
    
     
    private IEnumerator spawnEnemies()
    {
        Vector2 position2D;

            for (int i = 0; i < waves.Length; i++)
            {
                position2D = transform.position;
    
                for (int e = 0; e < waves[i]; e++)
                {
                GameObject enemy = EnemyPool.GetEnemy();
                enemy.transform.position = position2D + Random.insideUnitCircle * spawnrange;
                enemy.transform.rotation = Quaternion.identity;
                }
        yield return new WaitForSeconds(spawnInterval);
            }
    }

       


}
