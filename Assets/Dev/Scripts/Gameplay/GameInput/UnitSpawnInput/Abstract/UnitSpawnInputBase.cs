using StrategyGame.Events;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StrategyGame.Gameplay.GameInput.UnitSpawn
{
    public abstract class UnitSpawnInputBase : MonoBehaviour
    {
        protected abstract void SetUnitSpawnInput();
        protected abstract void SetUnitSpawnCursorInput();
        protected RuntimeUnitSpawnInputDataSO RuntimeUnitSpawnInputDataSO { get; private set; }
        protected bool IsUnitBuyClicked { get; private set; }

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            RuntimeUnitSpawnInputDataSO = allRuntimeInputDataSO.RuntimeUnitSpawnInputDataSO;
            RuntimeUnitSpawnInputDataSO.ResetData();
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted += OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnDenied += OnBuildingUnitSpawnDenied;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded += OnUnitSpawnSequenceEnded;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted -= OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnDenied -= OnBuildingUnitSpawnDenied;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded -= OnUnitSpawnSequenceEnded;
        }

        private void Update()
        {
            if (!IsUnitBuyClicked) return;
            SetUnitSpawnCursorInput();
            if (EventSystem.current.IsPointerOverGameObject()) return;
            SetUnitSpawnInput();
        }

        #region Events
        private void OnUnitSpawnSequenceStarted()
        {
            IsUnitBuyClicked = true;
            RuntimeUnitSpawnInputDataSO.UnitSpawnApplyTrigger = false;
        }

        private void OnBuildingUnitSpawnDenied()
        {
            RuntimeUnitSpawnInputDataSO.UnitSpawnApplyTrigger = false;
        }

        private void OnUnitSpawnSequenceEnded()
        {
            IsUnitBuyClicked = false;
            RuntimeUnitSpawnInputDataSO.ResetData();
        }
        #endregion
    }
}
