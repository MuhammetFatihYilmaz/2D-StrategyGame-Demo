using StrategyGame.Events;
using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameInput.UnitSpawn;
using StrategyGame.Management.ObjectPoolManagement;
using System.Collections;
using UnityEngine;

namespace StrategyGame.Gameplay.Building
{
    public class ProducibleBuilding : BuildingBase
    {
        [SerializeField] private LayerMask nonSpawnableLayerMask;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private SpriteRenderer spawnCursorRenderer;
        [SerializeField] private Transform spawnPoint;
        private RuntimeUnitSpawnInputDataSO runtimeUnitSpawnInputDataSO;
        private ProduceUnitBaseSO currentProduceUnitSO;

        private bool isUnitSpawnSeqStarted;
        private Vector2 cursorPos;
        private bool isPositionCanSpawn;

        protected override void Awake()
        {
            base.Awake();
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            runtimeUnitSpawnInputDataSO = allRuntimeInputDataSO.RuntimeUnitSpawnInputDataSO;
        }


        protected override void OnEnable()
        {
            base.OnEnable();
            GameEvents.GameplayEvents.OnUnitBuyClicked += OnUnitBuyClicked;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.GameplayEvents.OnUnitBuyClicked -= OnUnitBuyClicked;
        }

        private bool IsSpawnPointAvailable()
        {
            RaycastHit2D hit = Physics2D.Raycast(spawnPoint.position, Vector2.zero, 1f, nonSpawnableLayerMask);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject != this.gameObject)
                    return false;
            }

            return true;
        }

        private bool IsCursorOnNonSpawnable()
        {
            RaycastHit2D hit = Physics2D.CircleCast(runtimeUnitSpawnInputDataSO.SpawnIndicatorPos, 0.5f, Vector2.zero, 1f, nonSpawnableLayerMask);
            if (hit.collider != null) return true;

            return false;
        }

        private bool IsCursorFarFromBuilding()
        {
            RaycastHit2D hit = Physics2D.Raycast(runtimeUnitSpawnInputDataSO.SpawnIndicatorPos, Vector2.zero, 1f, groundLayerMask);
            if (hit.collider != null && (Vector2.Distance(transform.position, hit.point) < 3f))
            {
                return false;
            }
            return true;
        }

        private IEnumerator UnitSpawnPosSelectSequence()
        {
            isUnitSpawnSeqStarted = true;
            spawnCursorRenderer.gameObject.SetActive(true);
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted?.Invoke();

            while (isUnitSpawnSeqStarted)
            {

                cursorPos = runtimeUnitSpawnInputDataSO.SpawnIndicatorPos;

                isPositionCanSpawn = (!IsCursorOnNonSpawnable() && !IsCursorFarFromBuilding());

                spawnCursorRenderer.material.color = isPositionCanSpawn ? Color.white : Color.red;
                spawnCursorRenderer.transform.position = cursorPos;

                if (runtimeUnitSpawnInputDataSO.UnitSpawnApplyTrigger && !isPositionCanSpawn)
                {
                    GameEvents.GameplayEvents.OnUnitSpawnDenied?.Invoke();
                }

                if (runtimeUnitSpawnInputDataSO.UnitSpawnApplyTrigger && isPositionCanSpawn)
                {
                    SpawnUnit(cursorPos);
                    isUnitSpawnSeqStarted = false;
                }

                if (runtimeUnitSpawnInputDataSO.UnitSpawnCancelTrigger)
                {
                    isUnitSpawnSeqStarted = false;
                }

                yield return new WaitForEndOfFrame();
            }
            spawnCursorRenderer.gameObject.SetActive(false);
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded?.Invoke();
            isUnitSpawnSeqStarted = false;
        }

        private async void SpawnUnit(Vector2 position)
        {
            var unit = ObjectPoolManager.Instance.PullPrefab<ProduceUnitBase>(UID: currentProduceUnitSO.UID);
            await unit;
            unit.Result.Initialize(currentProduceUnitSO);
            unit.Result.transform.position = position;
        }

        #region Events

        private void OnUnitBuyClicked(BuildingBase building, ProduceUnitBaseSO produceUnitSO)
        {
            if (building != this) return;
            currentProduceUnitSO = produceUnitSO;

            if (isUnitSpawnSeqStarted) return;

            if (IsSpawnPointAvailable())
                SpawnUnit(spawnPoint.position);
            else
            {
                GameEvents.GameplayEvents.OnUnitSpawnPointNotAvailable?.Invoke();
                StartCoroutine(UnitSpawnPosSelectSequence());
            }
        }
        #endregion

    }
}
