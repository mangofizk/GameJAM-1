using UnityEditor.Rendering;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public int upgradeCostFireRate;
    public int upgradeCostHealth;
    public int upgradeCostDamage;
    public float fireRateReduction = 0.1f;
    public float healthIncrease = 10f;


    
    public void ApplyUpgradeFireRate()
    {
        if (MoneyManager.money >= upgradeCostFireRate)
        {
            PlayerManager.fireRate -= fireRateReduction;
            MoneyManager.money -= upgradeCostFireRate;
            upgradeCostFireRate += 10;
        }
        

    }
    public void ApplyUpgradeHealth()
    {
        if (MoneyManager.money >= upgradeCostHealth)
        {
            PlayerManager.health += healthIncrease;
            MoneyManager.money -= upgradeCostHealth;
            upgradeCostHealth += 10;
        }
        
    }
    
    public void UpgradePlayerDamage()
    {
        if (MoneyManager.money >= upgradeCostDamage)
        {
            PlayerManager.gundamage +=1;
            MoneyManager.money -= upgradeCostDamage;
            upgradeCostDamage += 10;
        }
      
    }


}
