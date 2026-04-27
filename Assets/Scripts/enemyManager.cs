using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static int enemyMaxHealth;
    private int health;
    public static int enemyDamage;

    PlayerManager playerManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        health = enemyMaxHealth;
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
        }
        Destroy(gameObject);
    }

    public void dealdamage(int damage)
    {
        health -= damage;
        Destroy(gameObject);
    }
}
