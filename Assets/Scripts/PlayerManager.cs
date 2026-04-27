using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float startingFirerate;
    public static float fireRate;
    private float timer;

    [SerializeField] private int startingHealth;
    public static float health;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        fireRate = startingFirerate;
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            timer = 0;
            shoot();
        }
    }

    public void shoot()
    {
        Debug.Log("bang");
    }

    public void dealDamage(int damage)
    {
        health -= damage;
    }
}
