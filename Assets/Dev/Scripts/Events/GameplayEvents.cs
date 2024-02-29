using StrategyGame.Gameplay.Building;
using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.Gameplay.GameMap;
using System;
using UnityEngine;

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
            public static Action<BuildingBase, ProduceUnitBaseSO> OnUnitBuyClicked;
            public static Action<BuildingBase> OnBuildingDestroyed;

            public static Action OnUnitSpawnSequenceStarted;
            public static Action OnUnitSpawnDenied;
            public static Action OnUnitSpawnSequenceEnded;
            public static Action OnUnitSpawnPointNotAvailable;

            public static Action<GameMapBase> OnGameMapSpawned;
            public static Action OnGameMapUnSpawned;
            public static Action OnEnemiesSpawnCompleted;

            public static Action<ProduceUnitBase> OnProduceUnitClicked;
            public static Action<MovableProduceUnitBase, Vector2> OnProduceUnitDestinationClicked;

            public static Action OnProduceUnitAttackDetectingStarted;
            public static Action OnProduceUnitAttackDetectingDenied;
            public static Action OnProduceUnitAttackDetectingEnded;

            public static Action OnSettingsMainMenuButtonClicked;
        }
    }
}
