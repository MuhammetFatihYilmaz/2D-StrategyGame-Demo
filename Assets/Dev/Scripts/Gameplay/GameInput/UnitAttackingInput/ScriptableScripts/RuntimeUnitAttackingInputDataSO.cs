using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.UnitAttacking
{
    [CreateAssetMenu(fileName = nameof(RuntimeUnitAttackingInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimeUnitAttackingInputDataSO))]
    public class RuntimeUnitAttackingInputDataSO : GameBaseSO
    {
        public Vector2 AttackingIndicatorPos;
        public bool AttackingApplyTrigger;
        public bool AttackingCancelTrigger;

        public void ResetData()
        {
            AttackingIndicatorPos = Vector2.zero;
            AttackingApplyTrigger = false;
            AttackingCancelTrigger = false;
        }
    }
}
