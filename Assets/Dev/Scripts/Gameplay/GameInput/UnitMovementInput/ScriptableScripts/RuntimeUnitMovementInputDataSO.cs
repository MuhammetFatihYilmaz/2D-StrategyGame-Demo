using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitMovement
{
    [CreateAssetMenu(fileName = nameof(RuntimeUnitMovementInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimeUnitMovementInputDataSO))]
    public class RuntimeUnitMovementInputDataSO : GameBaseSO
    {
        public Vector2 MovementIndicatorPos;

        public void ResetData()
        {
            MovementIndicatorPos = Vector2.zero;
        }
    }
}
