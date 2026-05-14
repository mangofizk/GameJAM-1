using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
public class evilManager : MonoBehaviour
{
    public static float evilHealth;
    public int evilMaxHealth;
    public static int evilMoney;
    public AudioClip evilDeathSound;
    public EnemySpawner enemySpawner;
    [SerializeField] public GameObject player;
    private float timer;
    private float EvilAttackSpeed = 1.5f;
    [SerializeField] public int NextSceneIndex;
    [SerializeField] private int EvilAttackDamage = 5;

    [SerializeField] Slider evilHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        enemySpawner = GetComponent<EnemySpawner>();
        evilHealth = evilMaxHealth;
        setEvilHealthBar();
    }


    public void evilDamage(int damage)
    {
        evilHealth -= damage;
        Debug.Log("ow. I took " + damage + " damage. I have " + evilHealth + " evil health left out of " + evilMaxHealth + " evilMaxHealth");

        setEvilHealthBar();

        if (evilHealth <= 0)
        {
            EvilDeathSound();
            SceneManager.LoadScene(NextSceneIndex);
        }
    }


    public void EvilAttack()
    {
            Debug.Log("wave ran out and i will shoot!");
            player.GetComponent<PlayerManager>().takeDamage(EvilAttackDamage);
    }
    private void setEvilHealthBar()
    {

        evilHealthBar.value = evilHealth / evilMaxHealth;
        Debug.Log("evilhealthbar value: " + evilHealthBar.value + " evil health: " + evilHealth + " evil maxHealth" + evilMaxHealth);
    }

    private void EvilDeathSound()
    {
        AudioSource.PlayClipAtPoint(evilDeathSound, transform.position);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= EvilAttackSpeed && enemySpawner.noWaves == true)
            {
                EvilAttack();
                timer = 0;
            }
    }
}
