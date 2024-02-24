using StrategyGame.Gameplay.Building;
using StrategyGame.Gameplay.Building.ProduceUnit;
using System;

namespace StrategyGame.Events
{
    public static partial class GameEvents
    {
        public static class GameplayEvents
        {
            public static Action<BuildingSO> OnBuildingBuyItemClicked;
            public static Action OnBuildingPlacementStarted;
            public static Action OnBuildingPlacementDenied;
            public static Action OnBuildingPlacementEnded;

            public static Action<BuildingBase> OnPlacedBuildingClicked;
            public static Action<BuildingBase, ProduceUnitSO> OnUnitBuyClicked;
            public static Action<BuildingBase> OnBuildingDestroyed;
        }
    }
}
