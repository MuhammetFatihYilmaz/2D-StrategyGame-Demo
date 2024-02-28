using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitSpawn
{
    public class UnitSpawnInputKeyboardHandler : UnitSpawnInputBase
    {
        protected override void SetUnitSpawnInput()
        {
            if (Input.GetMouseButton(0))
            {
                RuntimeUnitSpawnInputDataSO.UnitSpawnApplyTrigger = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                RuntimeUnitSpawnInputDataSO.UnitSpawnCancelTrigger = true;
            }
        }

        protected override void SetUnitSpawnCursorInput()
        {
            RuntimeUnitSpawnInputDataSO.SpawnIndicatorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
