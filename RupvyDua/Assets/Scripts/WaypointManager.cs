using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class WaypointManager : MonoBehaviour
{
    public Tilemap roadTilemap;
    public CarMovement carMovement;

    private List<Vector3> waypoints = new List<Vector3>();

    private void Update()
    {
        // Buat waypoints berdasarkan tile jalan yang dibuat
        waypoints.Clear();
        BoundsInt bounds = roadTilemap.cellBounds;
        UnityEngine.Tilemaps.TileBase[] allTiles = roadTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile == carMovement.roadTile)
                {
                    Vector3Int cellPos = new Vector3Int(x + bounds.x, y + bounds.y, 0);
                    waypoints.Add(roadTilemap.GetCellCenterWorld(cellPos));
                }
            }
        }

        carMovement.SetWaypoints(waypoints.ToArray());
    }
}
