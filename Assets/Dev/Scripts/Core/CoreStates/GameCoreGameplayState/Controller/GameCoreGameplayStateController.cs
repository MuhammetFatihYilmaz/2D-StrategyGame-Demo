using StrategyGame.Events;
using StrategyGame.GameCore.MVC;
using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayStateController : GameControllerBase<GameCoreGameplayState>
    {
        private GameMapSO currentGameMapSO;
        private GameMapBase currentMap;
        private GameInputHandler gameInputHandler;

        private void OnEnable()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected += OnGameMapSelected;

        }

        private void OnDisable()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected -= OnGameMapSelected;
        }

        public async void LoadGameMap()
        {
            var map = ObjectPoolManager.Instance.PullPrefab<GameMapBase>(UID: currentGameMapSO.UID);
            await map;
            currentMap = map.Result;
        }

        public void UnloadGameMap()
        {
            if (!currentMap) return;
            ObjectPoolManager.Instance.PushPrefab(currentMap);
        }

        public async void LoadGameInputHandler()
        {
            var handler = ObjectPoolManager.Instance.PullPrefab<GameInputHandler>();
            await handler;
            gameInputHandler = handler.Result;
        }

        public void UnloadGameInputHandler()
        {
            if (!gameInputHandler) return;
            ObjectPoolManager.Instance.PushPrefab(gameInputHandler);
        }

        #region Events
        private void OnGameMapSelected(GameMapSO data)
        {
            currentGameMapSO = data;
        }

        #endregion
    }
}
