using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs;  // List of road prefabs
    private GameObject selectedRoadPrefab;
    private GameObject currentRoad;

    private GridManager gridManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Update()
    {
        if (currentRoad != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentRoad.transform.position = gridManager.SnapToGrid(mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                PlaceRoad();
            }
        }
    }

    public void SelectRoad(int roadIndex)
    {
        if (roadIndex >= 0 && roadIndex < roadPrefabs.Count)
        {
            if (currentRoad != null)
            {
                Destroy(currentRoad);
            }
            selectedRoadPrefab = roadPrefabs[roadIndex];
            currentRoad = Instantiate(selectedRoadPrefab);
            EnableRoadCollider(currentRoad, false); // Disable collider initially
        }
    }

    private void EnableRoadCollider(GameObject road, bool enable)
    {
        road.GetComponent<BoxCollider2D>().enabled = enable;
    }

    private void PlaceRoad()
    {
        EnableRoadCollider(currentRoad, true);
        currentRoad = null;
    }
}
