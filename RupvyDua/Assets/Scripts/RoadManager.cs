using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject verticalRoadPrefab;
    public GameObject horizontalRoadPrefab;

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

    public void SelectVerticalRoad()
    {
        SelectRoad(verticalRoadPrefab);
    }

    public void SelectHorizontalRoad()
    {
        SelectRoad(horizontalRoadPrefab);
    }

    private void SelectRoad(GameObject roadPrefab)
    {
        if (currentRoad != null)
        {
            Destroy(currentRoad);
        }
        selectedRoadPrefab = roadPrefab;
        currentRoad = Instantiate(selectedRoadPrefab);
    }

    void PlaceRoad()
    {
        currentRoad = null;
    }
}
