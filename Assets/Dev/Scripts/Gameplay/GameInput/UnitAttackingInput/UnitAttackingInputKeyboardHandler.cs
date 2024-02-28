using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitAttacking
{
    public class UnitAttackingInputKeyboardHandler : UnitAttackingInputBase
    {
        protected override void SetUnitAttackingInput()
        {
            if (Input.GetMouseButton(1))
            {
                RuntimeUnitAttackingInputDataSO.AttackingApplyTrigger = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                RuntimeUnitAttackingInputDataSO.AttackingCancelTrigger = true;
            }
        }

        protected override void SetUnitAttackingCursor()
        {
            RuntimeUnitAttackingInputDataSO.AttackingIndicatorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
