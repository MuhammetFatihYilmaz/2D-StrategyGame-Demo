using StrategyGame.Events;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StrategyGame.Gameplay.GameInput.Placement
{
    public abstract class PlacementInputBase : MonoBehaviour
    {
        protected abstract void SetPlacementInput();
        protected abstract void SetPlacementCursor();
        protected RuntimePlacementInputDataSO RuntimePlacementInputDataSO { get; private set; }
        private bool isPlacementStarted;
        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllRuntimeInputDataSO>();
            RuntimePlacementInputDataSO = allRuntimeInputDataSO.RuntimePlacementInputDataSO;
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted += OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded += OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnBuildingPlacementDenied += OnBuildingPlacementDenied;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted -= OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded -= OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnBuildingPlacementDenied -= OnBuildingPlacementDenied;
        }

        private void Update()
        {
            if (!isPlacementStarted) return;
            SetPlacementCursor();
            if (EventSystem.current.IsPointerOverGameObject()) return;
            SetPlacementInput();
        }

        #region Events

        private void OnBuildingPlacementStarted()
        {
            isPlacementStarted = true;
        }

        private void OnBuildingPlacementDenied()
        {
            RuntimePlacementInputDataSO.PlacementApplyTrigger = false;
        }

        private void OnBuildingPlacementEnded()
        {
            isPlacementStarted = false;
            RuntimePlacementInputDataSO.ResetData();
        }
        #endregion
    }
}
