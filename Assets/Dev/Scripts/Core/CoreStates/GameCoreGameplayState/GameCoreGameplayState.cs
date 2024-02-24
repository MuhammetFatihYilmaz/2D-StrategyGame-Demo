using StrategyGame.GameCore.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayState : CoreStateBase
    {
        [SerializeField] private GameCoreGameplayStateView gameCoreGameplayStateView;
        [SerializeField] private GameCoreGameplayStateController gameCoreGameplayStateController;

        public override void OnSet()
        {
            Debug.Log("GameCoreGameplayState Onset");

            gameCoreGameplayStateView.LoadInGameplayWindow();
            gameCoreGameplayStateController.LoadGameMap();
            gameCoreGameplayStateController.LoadGameInputHandler();
        }

        public override void OnUnSet()
        {
            Debug.Log("GameCoreGameplayState OnUnset");
            gameCoreGameplayStateView.UnLoadInGameplayWindow();
            gameCoreGameplayStateController.UnloadGameMap();
            gameCoreGameplayStateController.UnloadGameInputHandler();
        }

        protected override IEnumerable<IMVC> ApplyMVCValues()
        {
            yield return gameCoreGameplayStateView;
        }
    }
}
