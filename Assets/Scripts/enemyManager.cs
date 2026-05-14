using Unity.VisualScripting;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static int enemyMaxHealth = 1;
    private int health;
    public static int enemyDamage = 1;
    private Animator animator;

    PlayerManager playerManager;

    private Rigidbody2D rb;

    
    void Start()
    {       
        health = enemyMaxHealth;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerManager>().takeDamage(enemyDamage);
            EnemyPool.evilEnemyPool.Release(gameObject);
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
            EnemyPool.evilEnemyPool.Release(gameObject);
        }
    }
}