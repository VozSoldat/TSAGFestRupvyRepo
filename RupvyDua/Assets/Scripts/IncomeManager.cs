using UnityEngine;
using System.Collections.Generic;

public class IncomeManager : MonoBehaviour
{
    public float incomeInterval = 5.0f; // Time interval in seconds for generating income
    private float timer;

    private List<Building> buildings;
    private ResourceManager resourceManager;

    void Start()
    {
        buildings = new List<Building>();
        resourceManager = FindObjectOfType<ResourceManager>();
        timer = incomeInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GenerateIncome();
            timer = incomeInterval;
        }
    }

    void GenerateIncome()
    {
        int totalIncome = 0;
        foreach (Building building in buildings)
        {
            totalIncome += building.income;
        }
        resourceManager.AddMoney(totalIncome);
    }

    public void RegisterBuilding(Building building)
    {
        buildings.Add(building);
    }
}
