using StrategyGame.Events;
using StrategyGame.Gameplay.Building;
using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameInput.Placement;
using StrategyGame.Management.ObjectPoolManagement;
using System.Collections;
using UnityEngine;

namespace StrategyGame.Gameplay.Placement
{
    public class PlacementController : MonoBehaviour
    {
        [SerializeField] private Grid placementGrid;
        [SerializeField] private SpriteRenderer placementCursorRenderer;
        [SerializeField] private LayerMask placementLayermask;
        [SerializeField] private LayerMask nonPlacableLayermask;

        private BuildingSO currentSelectedBuildingSO;
        private GridPlacedBuildingData gridPlacementBuildingData;
        private RuntimePlacementInputDataSO runtimePlacementInputDataSO;

        PlaceOccupyData currentOccupationData = new();
        private bool isPlacementSeqStarted;
        private Vector2 placementPos;
        private Vector2 cursorPos;
        private bool isPositionCanPlace;

        private void Awake()
        {
            gridPlacementBuildingData = new();
            placementCursorRenderer.gameObject.SetActive(false);
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            runtimePlacementInputDataSO = allRuntimeInputDataSO.RuntimePlacementInputDataSO;
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnBuildingBuyItemClicked += OnBuildingBuyItemClicked;
            GameEvents.GameplayEvents.OnBuildingDestroyed += OnBuildingDestroyed;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnBuildingBuyItemClicked -= OnBuildingBuyItemClicked;
            GameEvents.GameplayEvents.OnBuildingDestroyed -= OnBuildingDestroyed;
        }

        private async void PlaceBuilding()
        {
            PlaceOccupyData placedBuildingOccupationData = new();
            placedBuildingOccupationData.BuildingSpawnPosition = placementGrid.WorldToCell(GetPlacementPos());
            placedBuildingOccupationData.BuildingSize = currentSelectedBuildingSO.Size;

            var buildingTask = ObjectPoolManager.Instance.PullPrefab<BuildingBase>(UID: currentSelectedBuildingSO.UID);
            await buildingTask;
            buildingTask.Result.transform.position = placementGrid.GetCellCenterWorld(placedBuildingOccupationData.BuildingSpawnPosition);
            buildingTask.Result.Initialize(currentSelectedBuildingSO);
            placedBuildingOccupationData.PlacedBuilding = buildingTask.Result;

            gridPlacementBuildingData.AddPlacedBuilding(placedBuildingOccupationData);
        }

        private Vector2 GetPlacementPos()
        {
            RaycastHit2D hit = Physics2D.Raycast(runtimePlacementInputDataSO.PlacementIndicatorPos, Vector2.zero, 1f, placementLayermask);
            if (hit.collider != null)
            {
                placementPos = hit.point;
            }
            return placementPos;
        }

        private bool IsCursorOnNonPlacable()
        {
            RaycastHit2D hit = Physics2D.CircleCast(runtimePlacementInputDataSO.PlacementIndicatorPos, 1.5f ,Vector2.zero, 1f, nonPlacableLayermask);
            if (hit.collider != null) return true;

            return false;
        }


        private IEnumerator PlacementSelectSequence()
        {
            isPlacementSeqStarted = true;
            placementCursorRenderer.gameObject.SetActive(true);
            GameEvents.GameplayEvents.OnBuildingPlacementStarted?.Invoke();

            while (isPlacementSeqStarted)
            {

                cursorPos = GetPlacementPos();
                
                currentOccupationData.BuildingSpawnPosition = placementGrid.WorldToCell(cursorPos);
                currentOccupationData.BuildingSize = currentSelectedBuildingSO.Size;

                isPositionCanPlace = (gridPlacementBuildingData.IsBuildingCanPlace(currentOccupationData) && !IsCursorOnNonPlacable());

                placementCursorRenderer.material.color = isPositionCanPlace ? Color.white : Color.red;
                placementCursorRenderer.transform.position = cursorPos;

                if (runtimePlacementInputDataSO.PlacementApplyTrigger && !isPositionCanPlace)
                {
                    GameEvents.GameplayEvents.OnBuildingPlacementDenied?.Invoke();
                }

                if (runtimePlacementInputDataSO.PlacementApplyTrigger && isPositionCanPlace)
                {
                    PlaceBuilding();
                    isPlacementSeqStarted = false;
                }

                if (runtimePlacementInputDataSO.PlacementCancelTrigger)
                {
                    isPlacementSeqStarted = false;
                }

                yield return new WaitForEndOfFrame();
            }
            placementCursorRenderer.gameObject.SetActive(false);
            GameEvents.GameplayEvents.OnBuildingPlacementEnded?.Invoke();
            isPlacementSeqStarted = false;
        }

        #region Events
        private void OnBuildingBuyItemClicked(BuildingSO buildingSO)
        {
            currentSelectedBuildingSO = buildingSO;
            if (isPlacementSeqStarted) return;
            StartCoroutine(PlacementSelectSequence());
        }

        private void OnBuildingDestroyed(BuildingBase building)
        {
            gridPlacementBuildingData.RemovePlacedBuilding(building);
            ObjectPoolManager.Instance.PushPrefab(building, UID: building.BuildingSO.UID);
        }
        #endregion
    }
}
