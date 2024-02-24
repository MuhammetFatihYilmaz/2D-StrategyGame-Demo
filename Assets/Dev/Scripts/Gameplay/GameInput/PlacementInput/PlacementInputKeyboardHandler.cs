using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.Placement
{
    public class PlacementInputKeyboardHandler : PlacementInputBase
    {
        protected override void SetPlacementCursor()
        {
            RuntimePlacementInputDataSO.PlacementIndicatorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        protected override void SetPlacementInput()
        {
            if (Input.GetMouseButton(0))
            {
                RuntimePlacementInputDataSO.PlacementApplyTrigger = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                RuntimePlacementInputDataSO.PlacementCancelTrigger = true;
            }
        }
    }
}
