using UnityEngine;

public class Building : MonoBehaviour
{
    public int income = 10; // Amount of income this building generates per interval

    void Start()
    {
        IncomeManager incomeManager = FindObjectOfType<IncomeManager>();
        incomeManager.RegisterBuilding(this);
    }
}
