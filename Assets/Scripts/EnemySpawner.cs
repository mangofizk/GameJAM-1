using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public static float spawnInterval = 2.5f;
    [SerializeField] public Vector2 spawnrange = new Vector2(10f, 10f);

    
    private int enemyCount = 0;
    private int maxEnemies = 10;
    private int totalEnemiesSpawned = 0;
    private int maxTotalEnemies = 50;


    [SerializeField] int totalWaveAmounts;
    [SerializeField] int wavegrowthrate;
    [SerializeField] int waveStartEnemyAmount;
    [SerializeField] int BosswaveSizeIncrease;
    private int growthTracker = 0;

    void Start()
    {
       int[] waves = new int[totalWaveAmounts];

        for (int i = 0; i < waves.Length; i++)
        {
            if (wavegrowthrate <= growthTracker)
            {
                waveStartEnemyAmount++;
                growthTracker = 0;
            }
            else
            {
                growthTracker++;
            }
            
            waves[i] = waveStartEnemyAmount;

        }
        waves[waves.Length - 1] = (waveStartEnemyAmount + BosswaveSizeIncrease);

        StartCoroutine(spawnEnemies(waves));
    }
     
    
    private IEnumerator spawnEnemies(int[]waves)
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
        

    }
}
