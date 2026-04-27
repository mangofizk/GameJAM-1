using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static int money;
    public static float moneyIncreaseRate;
    private float timer;
    [SerializeField] TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
        moneyIncreaseRate = 2;
        changeText();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > moneyIncreaseRate)
        {
            money++;
            timer = 0;
            changeText();
        }
    }

    public void changeText()
    {
        text.text = money.ToString();
    }

    public void spendMoney(int spent)
    {
        money -= spent;
        changeText();
    }
}
