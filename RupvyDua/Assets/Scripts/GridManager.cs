using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float cellSize = 1f;
    public Vector2 gridSize = new Vector2(20, 20); // Adjust to your game world size

    public Vector2 SnapToGrid(Vector2 rawPosition)
    {
        float x = Mathf.Round(rawPosition.x / cellSize) * cellSize;
        float y = Mathf.Round(rawPosition.y / cellSize) * cellSize;
        return new Vector2(x, y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (float x = -gridSize.x / 2; x < gridSize.x / 2; x += cellSize)
        {
            Gizmos.DrawLine(new Vector3(x, -gridSize.y / 2, 0), new Vector3(x, gridSize.y / 2, 0));
        }

        for (float y = -gridSize.y / 2; y < gridSize.y / 2; y += cellSize)
        {
            Gizmos.DrawLine(new Vector3(-gridSize.x / 2, y, 0), new Vector3(gridSize.x / 2, y, 0));
        }
    }
}
