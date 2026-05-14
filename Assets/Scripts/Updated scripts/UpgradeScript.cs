using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public int upgradeCostFireRate = 5;
    public int upgradeCostHealth = 7;
    public int upgradeCostDamage = 7;
    public  int upgradeCostLLuck = 10;
    public  int upgradeCostMoneyIncreaseRate = 5;
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


    [SerializeField] PlayerManager playerManager;


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
        if (upgradeCountFireRate % 2 == 0)
        {
            enemyManager.enemyMaxHealth++;
            
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
       
        if (upgradeCountHealth % 2 == 0)
        {
             enemyManager.enemyDamage++;
           
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
       
        if (upgradeCountDamage % 2 == 0)
        {
            EnemySpawner.spawnInterval -= 0.1f;
            
        }
    }
    public void UpgradeMoneyIncreaseRate()
    {
        if (MoneyManager.money >= upgradeCostMoneyIncreaseRate)
        {

            //MoneyManager.moneyIncreaseRate -= 0.5f;
            playerManager.moneyupgrade();
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
