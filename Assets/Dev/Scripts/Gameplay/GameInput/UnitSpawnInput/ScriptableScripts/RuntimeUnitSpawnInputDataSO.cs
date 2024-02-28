using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitSpawn
{
    [CreateAssetMenu(fileName = nameof(RuntimeUnitSpawnInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimeUnitSpawnInputDataSO))]
    public class RuntimeUnitSpawnInputDataSO : GameBaseSO
    {
        public Vector2 SpawnIndicatorPos;
        public bool UnitSpawnApplyTrigger;
        public bool UnitSpawnCancelTrigger;

        public void ResetData()
        {
            SpawnIndicatorPos = Vector2.zero;
            UnitSpawnApplyTrigger = false;
            UnitSpawnCancelTrigger = false;
        }
    }
}
