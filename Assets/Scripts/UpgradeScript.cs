using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public int upgradeCostFireRate = 5;
    public int upgradeCostHealth = 5;
    public int upgradeCostDamage = 5;
    public int upgradeCostLLuck = 10;
    public int upgradeCostMoneyIncreaseRate = 20;
    public float fireRateReduction = 0.1f;
    public float healthIncrease = 10f;
    public Button upgradeButton;
    private int upgradeCountFireRate = 0;
    private int upgradeCountHealth = 0;
    private int upgradeCountDamage = 0;
    private int upgradeCountMoneyIncreaseRate = 0; 

    public void ApplyUpgradeFireRate()
    {
        if (MoneyManager.money >= upgradeCostFireRate)
        {
            upgradeButton.interactable = true;
            PlayerManager.fireRate -= fireRateReduction;
            MoneyManager.money -= upgradeCostFireRate;
            upgradeCostFireRate += 10;
            upgradeCountFireRate++; 
        }
        else
        {
            if (upgradeButton != null)
            {
                upgradeButton.interactable = false;
            }
        }
        switch (upgradeCountFireRate)
        {
            case 2 :
                enemyManager.enemyMaxHealth++;
                break;
            case 4 :
                enemyManager.enemyMaxHealth++;
                break;
            case 6 :
                enemyManager.enemyMaxHealth++;  
                break;
            case 8 :
                enemyManager.enemyMaxHealth++;
                break;
            case 10 :
                enemyManager.enemyMaxHealth++;
                break;
            case 12 :
                enemyManager.enemyMaxHealth++;
                break;
            case 14 :
                enemyManager.enemyMaxHealth++;  
                break;
            case 16 :
                enemyManager.enemyMaxHealth++;
                break;
        }
        

    }
    public void ApplyUpgradeHealth()
    {
        if (MoneyManager.money >= upgradeCostHealth)
        {
            upgradeButton.interactable = true;
            PlayerManager.health += healthIncrease;
            MoneyManager.money -= upgradeCostHealth;
            upgradeCostHealth += 10;
            upgradeCountHealth++;
        }
        else
        {
            if (upgradeButton != null)
            {
                upgradeButton.interactable = false;
            }
        }
        switch (upgradeCountHealth)
        {
            case 2 :
                enemyManager.enemyDamage++;
                break;
            case 4 :
                enemyManager.enemyDamage++;
                break;
            case 6 :
                enemyManager.enemyDamage++;  
                break;
            case 8 :
                enemyManager.enemyDamage++;
                break;
            case 10 :
                enemyManager.enemyDamage++;
                break;
            case 12 :
                enemyManager.enemyDamage++;
                break;
            case 14 :
                enemyManager.enemyDamage++;  
                break;
            case 16 :
                enemyManager.enemyDamage++;
                break;
        }
        
    }
    
    public void UpgradePlayerDamage()
    {
        if (MoneyManager.money >= upgradeCostDamage)
        {
            upgradeButton.interactable = true;
            PlayerManager.gundamage +=1;
            MoneyManager.money -= upgradeCostDamage;
            upgradeCostDamage += 10;
            upgradeCountDamage++;
        }
        else
        {
            if (upgradeButton != null)
            {
                upgradeButton.interactable = false;
            }
        }
        switch (upgradeCountDamage)
        {
            case 2 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
            case 4 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
            case 6 :
                EnemySpawner.spawnInterval -= 0.1f;  
                break;
            case 8 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
            case 10 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
            case 12 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
            case 14 :
                EnemySpawner.spawnInterval -= 0.1f;  
                break;
            case 16 :
                EnemySpawner.spawnInterval -= 0.1f;
                break;
        }
    }
    public void UpgradeMoneyIncreaseRate()
    {
        if (MoneyManager.money >= upgradeCostMoneyIncreaseRate)
        {
            upgradeButton.interactable = true;
            MoneyManager.moneyIncreaseRate -= 0.1f;
            MoneyManager.money -= upgradeCostMoneyIncreaseRate;
            upgradeCostMoneyIncreaseRate += 10;
            upgradeCountMoneyIncreaseRate++;
            
        }
        else
        {
            if (upgradeButton != null)
            {
                upgradeButton.interactable = false;
            }
        }
      
    }
    public void upgradeLuck()
    {
        if (MoneyManager.money >= upgradeCostLLuck)
        {
            upgradeButton.interactable = true;
            PlayerManager.criticalChance += 5;
            MoneyManager.money -= upgradeCostLLuck;
        }
        else
        {
            if (upgradeButton != null)
            {
                upgradeButton.interactable = false;
            }
        }
    }





}
