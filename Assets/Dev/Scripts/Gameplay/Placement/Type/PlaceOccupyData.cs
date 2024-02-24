using StrategyGame.Gameplay.Building;
using UnityEngine;

namespace StrategyGame.Gameplay.Placement
{
    public struct PlaceOccupyData
    {
        public BuildingBase PlacedBuilding;
        public Vector3Int BuildingSpawnPosition;
        public Vector2Int BuildingSize;
    }
}
