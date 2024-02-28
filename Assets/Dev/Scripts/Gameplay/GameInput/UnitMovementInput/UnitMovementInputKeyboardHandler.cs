using StrategyGame.Events;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitMovement
{
    public class UnitMovementInputKeyboardHandler : UnitMovementInputBase
    {
        protected override void SetUnitMovementInput()
        {
            if (Input.GetMouseButton(1) && IsCursorOnGround())
            {
                GameEvents.GameplayEvents.OnProduceUnitDestinationClicked?.Invoke(MovableProduceUnit,GetGroundPos());
                IsMovableUnitClicked = false;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && IsMovableUnitClicked)
            {
                IsMovableUnitClicked = false;
            }
        }

        protected override void SetMovementCursorInput()
        {
            RuntimeUnitMovementInputDataSO.MovementIndicatorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
