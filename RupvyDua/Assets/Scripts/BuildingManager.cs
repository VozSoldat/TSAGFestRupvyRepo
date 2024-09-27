using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public int[] buildingCostsMoney;
    public int[] buildingCostsMaterials;

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
                if (CanPlaceBuilding(currentBuilding))
                {
                    EnableBuildingCollider(currentBuilding, true);
                    PlaceBuilding();
                }
                else
                {
                    Debug.Log("Cannot place building here! Ensure it is adjacent to a road, and not overlapping with another building or road.");
                }
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
            EnableBuildingCollider(currentBuilding, false); // Disable collider initially
        }
    }

    bool CanPlaceBuilding(GameObject building)
    {
        Vector2 position = building.transform.position;
        BoxCollider2D collider = building.GetComponent<BoxCollider2D>();
        Vector2 size = collider.size;
        Vector2 center = (Vector2)building.transform.position + collider.offset;

        // Check for overlapping buildings and roads
        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, 0);
        foreach (Collider2D otherCollider in colliders)
        {
            if (otherCollider.gameObject != building &&
                (otherCollider.gameObject.layer == LayerMask.NameToLayer("Building") ||
                 otherCollider.gameObject.layer == LayerMask.NameToLayer("Road")))
            {
                return false;
            }
        }

        // Check adjacency to a road
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        foreach (Vector2 dir in directions)
        {
            Vector2 checkPos = center + dir * size;
            Collider2D roadCollider = Physics2D.OverlapBox(checkPos, size, 0, LayerMask.GetMask("Road"));
            if (roadCollider != null)
            {
                return true;
            }
        }

        return false;
    }

    void EnableBuildingCollider(GameObject building, bool enable)
    {
        building.GetComponent<BoxCollider2D>().enabled = enable;
    }

    void PlaceBuilding()
    {
        int buildingIndex = GetBuildingIndex();
        if (resourceManager.SpendResources(buildingCostsMoney[buildingIndex], buildingCostsMaterials[buildingIndex]))
        {
            // Trigger income generation
            currentBuilding.GetComponent<Building>().PlaceBuilding();
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
