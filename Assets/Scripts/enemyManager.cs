using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
    public static int enemyMaxHealth = 1;
    public int health;
    public static int enemyDamage = 1;
    private Animator animator;
    PlayerManager playerManager;
    [SerializeField] Slider healthbar;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            Destroy(gameObject);
        }
        
    }

    public void dealdamage(int damage)
    {
        Debug.Log("took damage");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("drone died");
            Destroy(gameObject);
        }
        else
        {
            healthbar.gameObject.SetActive(true);
            healthbar.maxValue = enemyMaxHealth;
            healthbar.value = health;
        }
    }
}
