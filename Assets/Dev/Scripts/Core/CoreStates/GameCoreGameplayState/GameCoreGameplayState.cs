using StrategyGame.GameCore.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayState : CoreStateBase
    {
        public override void OnSet()
        {
            Debug.Log("GameCoreGameplayState Onset");

        }

        public override void OnUnSet()
        {
            Debug.Log("GameCoreGameplayState OnUnset");

        }

        protected override IEnumerable<IMVC> ApplyMVCValues()
        {
            return default;
        }
    }
}
