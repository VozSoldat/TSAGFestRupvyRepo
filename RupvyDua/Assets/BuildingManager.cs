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
        currentBuilding = null;
    }
}
