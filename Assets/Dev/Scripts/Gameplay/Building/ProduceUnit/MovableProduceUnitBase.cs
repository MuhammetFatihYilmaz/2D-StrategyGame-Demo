using DG.Tweening;
using StrategyGame.Events;
using StrategyGame.Gameplay.PathFinding;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.Management.RuntimeGameplayDataManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    public class MovableProduceUnitBase : ProduceUnitBase
    {
        [SerializeField] private Pathfinding2D pathfinding2D;
        private List<Node2D> currentFindedPath = new();
        private int currentPathIndex = 0;
        private bool isMovementSequenceStarted;

        private RuntimeGameplayDataManager runtimeGameplayDataManager;
        private Tween unitMovementTween;
        private bool isIndicatorSequenceStarted;

        protected override void Awake()
        {
            base.Awake();
            runtimeGameplayDataManager = ObjectPoolManager.Instance.PullManager<RuntimeGameplayDataManager>();
            pathfinding2D.Initialize(runtimeGameplayDataManager.GetCurrentMap().Grid);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            GameEvents.GameplayEvents.OnProduceUnitDestinationClicked += OnProduceUnitDestinationClicked;
            GameEvents.GameplayEvents.OnBuildingPlacementStarted += OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded += OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted += OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded += OnUnitSpawnSequenceEnded;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.GameplayEvents.OnProduceUnitDestinationClicked -= OnProduceUnitDestinationClicked;
            GameEvents.GameplayEvents.OnBuildingPlacementStarted -= OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded -= OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted -= OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded -= OnUnitSpawnSequenceEnded;
        }

        private IEnumerator MovementSequence()
        {
            isMovementSequenceStarted = true;
            while (isMovementSequenceStarted)
            {
                if (currentPathIndex > currentFindedPath.Count - 1)
                {
                    isMovementSequenceStarted = false;
                    break;
                }

                Vector2 pos = currentFindedPath[currentPathIndex].WorldPosition;

                unitMovementTween = transform.DOMove(pos, 0.5f).SetEase(Ease.Linear);
                yield return unitMovementTween.WaitForCompletion();
                currentPathIndex++;
            }
            isMovementSequenceStarted = false;
        }

        private void SetMovementSequence(Vector2 destination)
        {
            pathfinding2D.FindPath(transform.position, destination);
            if (pathfinding2D.GetFindedPath().Count < 1) return;
            currentFindedPath = pathfinding2D.GetFindedPath();
            currentPathIndex = 0;
            if (isMovementSequenceStarted) return;

            StartCoroutine(MovementSequence());
        }

        #region Events
        private void OnProduceUnitDestinationClicked(MovableProduceUnitBase unit, Vector2 destination)
        {
            if (isIndicatorSequenceStarted) return;
            if (unit != this) return;
            SetMovementSequence(destination);
        }

        private void OnBuildingPlacementStarted()
        {
            isIndicatorSequenceStarted = true;
        }

        private void OnBuildingPlacementEnded()
        {
            isIndicatorSequenceStarted = false;
        }

        private void OnUnitSpawnSequenceStarted()
        {
            isIndicatorSequenceStarted = true;
        }

        private void OnUnitSpawnSequenceEnded()
        {
            isIndicatorSequenceStarted = false;
        }
        #endregion
    }
}
