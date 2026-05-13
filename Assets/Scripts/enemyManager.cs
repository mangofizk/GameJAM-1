using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static int enemyMaxHealth = 1;
    private int health;
    public static int enemyDamage = 1;
    private Animator animator;
    PlayerManager playerManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        health = enemyMaxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerManager>().takeDamage(enemyDamage);
            EnemySpawner.enemyPool.Release(gameObject);
        }
        
    }

    public void dealdamage(int damage)
    {
        Debug.Log("took damage");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("drone died");
            //animator.Play("robo death");
            EnemySpawner.enemyPool.Release(gameObject);
        }
    }
}
