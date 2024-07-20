using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab;
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

    public void SelectRoad()
    {
        if (currentRoad != null)
        {
            Destroy(currentRoad);
        }
        currentRoad = Instantiate(roadPrefab);
    }

    void PlaceRoad()
    {
        currentRoad = null;
    }
}
