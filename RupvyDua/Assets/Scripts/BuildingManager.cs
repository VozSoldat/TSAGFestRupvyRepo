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
                    Debug.Log("Cannot place building here! Space is occupied.");
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
        Vector2 size = building.GetComponent<BoxCollider2D>().size;
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, size, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != building && collider.gameObject.layer == LayerMask.NameToLayer("Building"))
            {
                return false;
            }
        }

        // Check adjacency to a road
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        foreach (Vector2 dir in directions)
        {
            Vector2 checkPos = position + dir;
            Collider2D roadCollider = Physics2D.OverlapPoint(checkPos, LayerMask.GetMask("Road"));
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
