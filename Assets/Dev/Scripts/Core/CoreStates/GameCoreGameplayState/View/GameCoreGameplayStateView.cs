using StrategyGame.Events;
using StrategyGame.GameCore.MVC;
using StrategyGame.UI.Window.InGameplayWindow;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayStateView : GameViewBase<GameCoreGameplayState>
    {
        private bool isEnemiesSpawned;
        protected override void OnEnable()
        {
            base.OnEnable();
            GameEvents.GameplayEvents.OnEnemiesSpawnCompleted += OnEnemiesSpawnCompleted;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.GameplayEvents.OnEnemiesSpawnCompleted -= OnEnemiesSpawnCompleted;
        }
        public async void LoadInGameplayWindow()
        {
            var task = LoadWindow<InGameplayWindow>();
            await task;
        }

        public void UnLoadInGameplayWindow()
        {
            UnLoadWindow<InGameplayWindow>();
        }

        public void StartLoadingWindow()
        {
            isEnemiesSpawned = false;
            MVCDriver.CommonValue.LoadingWindow.StartLoadingTask(new WaitUntil(() => isEnemiesSpawned));
        }

        #region Events
        private void OnEnemiesSpawnCompleted()
        {
            isEnemiesSpawned = true;
        }
        #endregion
    }
}
