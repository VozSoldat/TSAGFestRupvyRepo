using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingPrefabs; // Array to hold different building prefabs
    public int[] buildingCostsMoney;     // Array to hold the money cost for each building
    public int[] buildingCostsMaterials; // Array to hold the material cost for each building

    private GameObject selectedBuildingPrefab;
    private GameObject currentBuilding;

    private GridManager gridManager;
    private ResourceManager resourceManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    void Update()
    {
        if (currentBuilding != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBuilding.transform.position = gridManager.SnapToGrid(mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
    }

    public void SelectBuilding(int index)
    {
        if (index >= 0 && index < buildingPrefabs.Length)
        {
            selectedBuildingPrefab = buildingPrefabs[index];
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
            }
            currentBuilding = Instantiate(selectedBuildingPrefab);
        }
    }

    void PlaceBuilding()
    {
        int buildingIndex = GetBuildingIndex();
        if (resourceManager.SpendResources(buildingCostsMoney[buildingIndex], buildingCostsMaterials[buildingIndex]))
        {
            currentBuilding = null;
        }
        else
        {
            Destroy(currentBuilding);
            currentBuilding = null;
            Debug.Log("Not enough resources to place the building!");
        }
    }

    int GetBuildingIndex()
    {
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            if (buildingPrefabs[i] == selectedBuildingPrefab)
                return i;
        }
        return -1;
    }
}
