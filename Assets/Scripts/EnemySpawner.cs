using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public static float spawnInterval = 2.5f;
    [SerializeField] public Vector2 spawnrange = new Vector2(10f, 10f);

    private int[] waves = {1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6};

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
                Instantiate(enemyPrefab, position2D + Random.insideUnitCircle * spawnrange, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
        

        {
        
        
        }
    }
}
