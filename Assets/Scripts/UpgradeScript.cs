using UnityEditor.Rendering;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public int upgradeCost;
    public float fireRateReduction = 0.1f;
    public float healthIncrease;

    public void ApplyUpgradeFireRate()
    {
        if (MoneyManager.money >= upgradeCost)
        {
            PlayerManager.fireRate -= fireRateReduction;
            MoneyManager.money -= upgradeCost;
        }
    }
    public void ApplyUpgradeHealth()
    {
        if (MoneyManager.money >= upgradeCost)
        {
            PlayerManager.health += healthIncrease;
            MoneyManager.money -= upgradeCost;
        }
    }
    public void UpgradePlayerDamage()
    {
        if (MoneyManager.money >= upgradeCost)
        {
            
            MoneyManager.money -= upgradeCost;
        }
    }
}
