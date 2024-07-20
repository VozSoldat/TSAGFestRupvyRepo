using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int money = 1000;
    public int materials = 500;

    public Text moneyText;
    public Text materialsText;

    void Start()
    {
        UpdateResourceUI();
    }

    public bool SpendResources(int moneyCost, int materialCost)
    {
        if (money >= moneyCost && materials >= materialCost)
        {
            money -= moneyCost;
            materials -= materialCost;
            UpdateResourceUI();
            return true;
        }
        return false;
    }

    public void GainResources(int moneyAmount, int materialAmount)
    {
        money += moneyAmount;
        materials += materialAmount;
        UpdateResourceUI();
    }

    void UpdateResourceUI()
    {
        moneyText.text = "Money: " + money;
        materialsText.text = "Materials: " + materials;
    }
}
