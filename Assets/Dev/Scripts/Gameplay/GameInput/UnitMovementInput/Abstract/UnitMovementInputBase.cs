using StrategyGame.Events;
using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace StrategyGame.Gameplay.GameInput.UnitMovement
{
    public abstract class UnitMovementInputBase : MonoBehaviour
    {
        protected abstract void SetUnitMovementInput();
        protected abstract void SetMovementCursorInput();
        protected RuntimeUnitMovementInputDataSO RuntimeUnitMovementInputDataSO { get; private set; }
        protected MovableProduceUnitBase MovableProduceUnit { get; private set; }
        protected bool IsMovableUnitClicked;
        private Vector2Int clickedGroundPos = Vector2Int.zero;
        private LayerMask groundLayerMask;

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            RuntimeUnitMovementInputDataSO = allRuntimeInputDataSO.RuntimeUnitMovementInputDataSO;
            RuntimeUnitMovementInputDataSO.ResetData();
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnProduceUnitClicked += OnProduceUnitClicked;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnProduceUnitClicked -= OnProduceUnitClicked;
        }

        private void Update()
        {
            if (!IsMovableUnitClicked) return;
            SetMovementCursorInput();
            if (EventSystem.current.IsPointerOverGameObject()) return;
            SetUnitMovementInput();
        }

        public void Initialize(LayerMask groundLayerMask)
        {
            this.groundLayerMask = groundLayerMask;
        }

        protected bool IsCursorOnGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(RuntimeUnitMovementInputDataSO.MovementIndicatorPos, Vector2.zero, 1f, groundLayerMask);

            if (hit.collider != null) return true;
            return false;
        }

        protected Vector2 GetGroundPos()
        {
            RaycastHit2D hit = Physics2D.Raycast(RuntimeUnitMovementInputDataSO.MovementIndicatorPos, Vector2.zero, 1f, groundLayerMask);

            if (hit.collider != null)
            {
                hit.collider.TryGetComponent(out Tilemap tilemap);
                if (tilemap)
                {
                    var pos = tilemap.WorldToCell(hit.point);
                    clickedGroundPos = (Vector2Int)pos;
                }
            }
            return clickedGroundPos;
        }

        #region Events
        private void OnProduceUnitClicked(ProduceUnitBase unit)
        {
            if (unit is MovableProduceUnitBase)
            {
                IsMovableUnitClicked = true;
                MovableProduceUnit = unit as MovableProduceUnitBase;
            }
        }
        #endregion
    }
}
