using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingPrefabs; // Array to hold different building prefabs
    private GameObject selectedBuildingPrefab;
    private GameObject currentBuilding;

    void Update()
    {
        if (currentBuilding != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBuilding.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
        else
        {
            Debug.LogWarning("currentBuilding is null in Update method.");
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
        else
        {
            Debug.LogError("Index out of range when selecting building.");
        }
    }

    void PlaceBuilding()
    {
        if (currentBuilding != null)
        {
            currentBuilding = null;
        }
        else
        {
            Debug.LogWarning("Trying to place a building, but currentBuilding is null.");
        }
    }
}
