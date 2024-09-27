using UnityEngine;

public class Building : MonoBehaviour
{
    public int income;  // The income this building generates per second
    private bool isPlaced = false;
    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    public void PlaceBuilding()
    {
        isPlaced = true;
        InvokeRepeating("GenerateIncome", 1f, 1f);
    }

    void GenerateIncome()
    {
        if (isPlaced)
        {
            resourceManager.AddMoney(income);
        }
    }
}
