using StrategyGame.Events;
using StrategyGame.GameCore.CoreStates.GameplayState;
using StrategyGame.GameCore.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.MainMenuState
{
    public class GameCoreMainMenuState : CoreStateBase
    {
        [SerializeField] private GameCoreMainMenuStateView gameCoreMainMenuStateView;
        protected override void Awake()
        {
            base.Awake();
        }

        protected override IEnumerable<IMVC> ApplyMVCValues()
        {
            yield return gameCoreMainMenuStateView;
        }

        public override void OnSet()
        {
            GameEvents.MainMenuEvents.OnStartGameButtonClicked += OnStartGameButtonClicked;
            GameEvents.MainMenuEvents.OnExitGameButtonClicked += OnExitGameButtonClicked;

            gameCoreMainMenuStateView.LoadMainMenuWindow();
            Debug.Log("GameCoreMainMenuState Onset");
        }

        public override void OnUnSet()
        {
            GameEvents.MainMenuEvents.OnStartGameButtonClicked -= OnStartGameButtonClicked;
            GameEvents.MainMenuEvents.OnExitGameButtonClicked -= OnExitGameButtonClicked;

            gameCoreMainMenuStateView.UnLoadMainMenuWindow();
            Debug.Log("GameCoreMainMenuState Unset");
        }

        #region Events
        private void OnStartGameButtonClicked()
        {
            StateDriver.SwitchState<GameCoreGameplayState>();
        }
        private void OnExitGameButtonClicked()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        #endregion
    }
}
