using StrategyGame.Events;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StrategyGame.Gameplay.GameInput.UnitAttacking
{
    public abstract class UnitAttackingInputBase : MonoBehaviour
    {
        protected abstract void SetUnitAttackingInput();
        protected abstract void SetUnitAttackingCursor();

        protected RuntimeUnitAttackingInputDataSO RuntimeUnitAttackingInputDataSO { get; private set; }
        private bool isAttackingUnitClicked;

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            RuntimeUnitAttackingInputDataSO = allRuntimeInputDataSO.RuntimeUnitAttackingInputDataSO;
            RuntimeUnitAttackingInputDataSO.ResetData();
        }
        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingStarted += OnProduceUnitAttackDetectingStarted;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingDenied += OnProduceUnitAttackDetectingDenied;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingEnded += OnProduceUnitAttackDetectingEnded;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingStarted -= OnProduceUnitAttackDetectingStarted;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingDenied -= OnProduceUnitAttackDetectingDenied;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingEnded -= OnProduceUnitAttackDetectingEnded;
        }

        private void Update()
        {
            if (!isAttackingUnitClicked) return;
            SetUnitAttackingCursor();
            if (EventSystem.current.IsPointerOverGameObject()) return;
            SetUnitAttackingInput();
        }

        #region Events
        private void OnProduceUnitAttackDetectingStarted()
        {
            isAttackingUnitClicked = true;
        }

        private void OnProduceUnitAttackDetectingDenied()
        {
            RuntimeUnitAttackingInputDataSO.AttackingApplyTrigger = false;
        }

        private void OnProduceUnitAttackDetectingEnded()
        {
            isAttackingUnitClicked = false;
            RuntimeUnitAttackingInputDataSO.ResetData();
        }
        #endregion
    }
}
