using UnityEngine;
using UnityEngine.UI;

public class evilManager : MonoBehaviour
{
    public static float evilHealth;
    public int evilMaxHealth;
    public static int evilMoney;

    [SerializeField] Slider evilHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            //det er her Leo
        }
    }

    private void setEvilHealthBar()
    {
        
        evilHealthBar.value = evilHealth / evilMaxHealth;
        Debug.Log("evilhealthbar value: " + evilHealthBar.value + " evil health: " + evilHealth + " evil maxHealth" + evilMaxHealth);
    }
}
