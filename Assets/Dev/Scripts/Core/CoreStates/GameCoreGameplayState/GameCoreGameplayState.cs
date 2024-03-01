using StrategyGame.Events;
using StrategyGame.GameCore.CoreStates.MainMenuState;
using StrategyGame.GameCore.MVC;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.Management.SceneManagement;
using System;
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

            GameEvents.GameplayEvents.OnAllBuildingsDestroyed += OnAllBuildingsDestroyed;

            gameCoreGameplayStateView.StartLoadingWindow();
            gameCoreGameplayStateView.LoadInGameplayWindow();
            gameCoreGameplayStateController.LoadGameInputHandler();
            gameCoreGameplayStateController.LoadEnemySpawnHandler();
            gameCoreGameplayStateController.LoadInGameplayCameraHandler();
            gameCoreGameplayStateController.LoadGameMap();
        }

        public override void OnUnSet()
        {
            Debug.Log("GameCoreGameplayState OnUnset");

            GameEvents.GameplayEvents.OnAllBuildingsDestroyed -= OnAllBuildingsDestroyed;

            gameCoreGameplayStateView.UnLoadInGameplayWindow();
            gameCoreGameplayStateController.UnLoadGameMap();
            gameCoreGameplayStateController.UnLoadGameInputHandler();
            gameCoreGameplayStateController.UnLoadEnemySpawnHandler();
            gameCoreGameplayStateController.UnLoadInGameplayCameraHandler();
        }

        protected override IEnumerable<IMVC> ApplyMVCValues()
        {
            yield return gameCoreGameplayStateView;
        }

        #region Events

        private void OnAllBuildingsDestroyed()
        {
            StateDriver.SwitchState<GameCoreMainMenuState>();
            ObjectPoolManager.Instance.PullManager<SceneManager>().LoadScene(sceneType: SceneType.Menu);
        }
        #endregion
    }
}
