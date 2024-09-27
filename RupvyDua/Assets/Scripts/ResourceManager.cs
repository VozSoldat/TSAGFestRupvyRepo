using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int money;
    public Text moneyText;

    void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
    }

    public bool SpendResources(int costMoney, int costMaterials)
    {
        if (money >= costMoney)
        {
            money -= costMoney;
            UpdateMoneyUI();
            return true;
        }
        return false;
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "Money: " + money.ToString();
    }
}
