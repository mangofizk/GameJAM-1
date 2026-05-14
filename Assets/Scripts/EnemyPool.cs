using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private ObjectPool<GameObject> evilEnemyPool;

    private void Awake()
    {
        evilEnemyPool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                GameObject e = Instantiate(enemyPrefab);
                e.SetActive(false);
                return e;
            },

            actionOnGet: e =>
            {
                e.SetActive(true);
            },

            actionOnRelease: e =>
            {
                e.SetActive(false);
            },

            actionOnDestroy: e =>
            {
                Destroy(e);
            },

            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 30
        );
    }

    public GameObject GetEnemy()
    {
        return evilEnemyPool.Get();
    }

    public void ReturnEnemy(GameObject enemy)
    {
        evilEnemyPool.Release(enemy);
    }
}