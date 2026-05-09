using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public static int upgradeCostFireRate = 5;
    public static int upgradeCostHealth = 7;
    public static int upgradeCostDamage = 7;
    public static int upgradeCostLLuck = 10;
    public static int upgradeCostMoneyIncreaseRate = 5;
    public float fireRateReduction = 0.1f;
    public float healthIncrease = 10f;
    public Button upgradeButtonFireRate;
    public Button upgradeButtonHealth;
    public Button upgradeButtonDamage;
    public Button upgradeButtonMoneyIncreaseRate;
    public Button upgradeButtonLuck;
    private int upgradeCountFireRate = 0;
    private int upgradeCountHealth = 0;
    private int upgradeCountDamage = 0;
    private int upgradeCountMoneyIncreaseRate = 0;


    private void Start()
    {
        upgradeButtonFireRate.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostFireRate.ToString();
        upgradeButtonHealth.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostHealth.ToString();
        upgradeButtonDamage.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostDamage.ToString();
        upgradeButtonMoneyIncreaseRate.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostMoneyIncreaseRate.ToString();
        
    }
    public void ApplyUpgradeFireRate()
    {
        if (MoneyManager.money >= upgradeCostFireRate)
        {
            
            PlayerManager.fireRate -= fireRateReduction;
            Debug.Log(PlayerManager.fireRate);
            MoneyManager.money -= upgradeCostFireRate;
            upgradeCostFireRate += 5;
            upgradeCountFireRate++;
            upgradeButtonFireRate.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostFireRate.ToString();
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
            
            PlayerManager.health += healthIncrease;
            MoneyManager.money -= upgradeCostHealth;
            upgradeCostHealth += 5;
            upgradeCountHealth++;
            upgradeButtonHealth.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostHealth.ToString();
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
    
    public void ApplyUpgradePlayerDamage()
    {
        if (MoneyManager.money >= upgradeCostDamage)
        {
            
            PlayerManager.gundamage +=1;
            MoneyManager.money -= upgradeCostDamage;
            upgradeCostDamage += 10;
            upgradeCountDamage++;
            upgradeButtonDamage.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostDamage.ToString();
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
            
            MoneyManager.moneyIncreaseRate -= 0.5f;
            MoneyManager.money -= upgradeCostMoneyIncreaseRate;
            upgradeCostMoneyIncreaseRate += 10;
            upgradeCountMoneyIncreaseRate++;
            upgradeButtonMoneyIncreaseRate.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCostMoneyIncreaseRate.ToString();
        }
       
      
    }
  
void Update()
{
    if (upgradeButtonFireRate != null)
        upgradeButtonFireRate.interactable = MoneyManager.money >= upgradeCostFireRate;

    if (upgradeButtonHealth != null)
        upgradeButtonHealth.interactable = MoneyManager.money >= upgradeCostHealth;

    if (upgradeButtonDamage != null)
        upgradeButtonDamage.interactable = MoneyManager.money >= upgradeCostDamage;

    if (upgradeButtonMoneyIncreaseRate != null)
        upgradeButtonMoneyIncreaseRate.interactable = MoneyManager.money >= upgradeCostMoneyIncreaseRate;

    if (upgradeButtonLuck != null)
        upgradeButtonLuck.interactable = MoneyManager.money >= upgradeCostLLuck;
}





}
