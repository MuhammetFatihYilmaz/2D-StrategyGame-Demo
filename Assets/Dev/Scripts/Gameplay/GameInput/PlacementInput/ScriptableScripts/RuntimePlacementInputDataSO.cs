using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.Placement
{
    [CreateAssetMenu(fileName = nameof(RuntimePlacementInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimePlacementInputDataSO))]
    public class RuntimePlacementInputDataSO : GameBaseSO
    {
        public Vector2 PlacementIndicatorPos;
        public bool PlacementApplyTrigger;
        public bool PlacementCancelTrigger;

        public void ResetData()
        {
            PlacementApplyTrigger = false;
            PlacementCancelTrigger = false;
            PlacementIndicatorPos = Vector2.zero;
        }
    }
}
