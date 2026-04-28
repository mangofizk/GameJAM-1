using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float startingFirerate;
    public static float fireRate;

    [SerializeField] int startingGundamage;
    public static int gundamage;
    private float timer;


    [SerializeField] private int startingHealth;
    public static float health;

    public GameObject[] enemies;

    [SerializeField] Slider healthbar;

    [SerializeField] GameObject evilguy;
    evilManager evilManager;

    Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        timer = 0;
        fireRate = startingFirerate;
        health = startingHealth;
        gundamage = startingGundamage;

        setHealthBar();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            timer = 0;
            animator.Play("Shooting");
        }
    }

    public void shoot()
    {
       
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("bang");
        

        if (enemies.Length == 0)
        {
            evilguy.GetComponent<evilManager>().evilDamage(gundamage);
        } else
        {

            GameObject nearestEnemy = enemies[0];
            float distanceToNearest = Vector3.Distance(transform.position, nearestEnemy.transform.position);

            for (int i = 1; i < enemies.Length; i++)
            {
                float distanceToCurrent = Vector3.Distance(transform.position, enemies[i].transform.position);

                if (distanceToCurrent < distanceToNearest)
                {
                    nearestEnemy = enemies[i];
                    distanceToNearest = distanceToCurrent;
                }
            }

            nearestEnemy.GetComponent<enemyManager>().dealdamage(gundamage);
        }
    }


    public void takeDamage(int damage)
    {
        health -= damage;
        setHealthBar();

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void setHealthBar()
    {
        healthbar.value = health / startingHealth;

    }

}
