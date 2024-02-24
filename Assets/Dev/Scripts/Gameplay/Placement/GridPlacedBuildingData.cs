using StrategyGame.Gameplay.Building;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Placement
{
    public class GridPlacedBuildingData
    {
        private Dictionary<BuildingBase, List<Vector3Int>> placedBuildingValuePair = new();

        public void AddPlacedBuilding(PlaceOccupyData placeData)
        {
            var placedPos = GetPlacePos(placeData);
            placedBuildingValuePair[placeData.PlacedBuilding] = placedPos;
        }

        public void RemovePlacedBuilding(BuildingBase building)
        {
            if (!placedBuildingValuePair.ContainsKey(building)) return;

            placedBuildingValuePair.Remove(building);
        }

        private List<Vector3Int> GetPlacePos(PlaceOccupyData placeData)
        {
            List<Vector3Int> placedPosList = new();
            for (int x = 0; x < placeData.BuildingSize.x; x++)
            {
                for (int y = 0; y < placeData.BuildingSize.y; y++)
                {
                    int offsetX = (int)Math.Ceiling((double)placeData.BuildingSize.x / 2);
                    int offsetY = (int)Math.Ceiling((double)placeData.BuildingSize.y / 2);
                    placedPosList.Add(placeData.BuildingSpawnPosition + new Vector3Int(x - offsetX, y - offsetY, 0));
                }
            }
            return placedPosList;
        }

        public bool IsBuildingCanPlace(PlaceOccupyData placeData)
        {
            var tryingPlacePos = GetPlacePos(placeData);

            foreach (var placedBuildingPosList in placedBuildingValuePair.Values)
            {
                foreach (var placedPos in placedBuildingPosList)
                {
                    if (tryingPlacePos.Contains(placedPos)) return false;
                }
            }
            return true;
        }
    }
}
