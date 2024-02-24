using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.Placement
{
    [CreateAssetMenu(fileName = nameof(RuntimePlacementInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimePlacementInputDataSO))]
    public class RuntimePlacementInputDataSO : GameBaseSO
    {
        public bool PlacementApplyTrigger;
        public bool PlacementCancelTrigger;
        public Vector3 PlacementIndicatorPos;

        public void ResetData()
        {
            PlacementApplyTrigger = false;
            PlacementCancelTrigger = false;
            PlacementIndicatorPos = Vector3.zero;
        }
    }
}
