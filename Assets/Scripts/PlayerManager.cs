using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float startingFirerate;
    public static float fireRate;
    [SerializeField] public static int luck = 5;
    

    [SerializeField] int startingGundamage;
    public static int gundamage;
    private float timer;

    public GameObject gameoverimage;
    [SerializeField] private int startingHealth;
    public static float health;

    public GameObject[] enemies;

    [SerializeField] Slider healthbar;

    [SerializeField] GameObject evilguy;
    evilManager evilManager;

    Animator animator;

    public AudioClip ShootingSound;
    public AudioClip EnemyDamageSound;
    public BigBumboBlast BlastScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Time.timeScale = 1f;
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
        if (timer > fireRate && BlastScript.blastBool == false)
        {
            timer = 0;
            animator.Play("Shooting");
        }
    }

    public void shoot()
    {
       
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log("bang");
        if (enemies.Length == 0)
        {
            int roll = Random.Range(0, 100);
            if (roll < luck)
            
            {
                Debug.Log("Critical hit! " + roll + "Enemy Health at:" + evilManager.evilHealth);
                PlayShootingSound();
                evilguy.GetComponent<evilManager>().evilDamage(gundamage*5);
                
            }
        }

        if (enemies.Length == 0)
        {
            PlayShootingSound();
            evilguy.GetComponent<evilManager>().evilDamage(gundamage);
        } else
        {
            PlayShootingSound();
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
        PlayEnemyDamageSound();
        health -= damage;
        setHealthBar();

        if (health <= 0)
        { 
          Die();
        }
    }

    private void setHealthBar()
    {
        healthbar.value = health / startingHealth;

    }

    public void PlayShootingSound()
    {
        AudioSource.PlayClipAtPoint(ShootingSound, transform.position);
    }

    public void PlayEnemyDamageSound()
    {
        AudioSource.PlayClipAtPoint(EnemyDamageSound, transform.position);
    }

    public void Die()
    {
        gameoverimage.SetActive(true);
        Time.timeScale = 0f;
    }

}
