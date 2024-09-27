using UnityEngine;

namespace BuildingSystem
{
    public class ConstructionLayer : TilemapsLayer
    {
        public void Build(Vector3 worldCoords, BuildablesItems item)
        {
            var coords = _tilemap.WorldToCell(worldCoords);
            if (item.Tile != null)
            {
                _tilemap.SetTile(coords, item.Tile);
            }
        }
    }
}

