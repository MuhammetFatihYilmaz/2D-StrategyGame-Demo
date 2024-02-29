using StrategyGame.Events;
using StrategyGame.GameCore.MVC;
using StrategyGame.Gameplay.Enemy;
using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Gameplay.InGameplayCamera;
using StrategyGame.Management.ObjectPoolManagement;
using System.Threading.Tasks;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayStateController : GameControllerBase<GameCoreGameplayState>
    {
        private GameMapSO currentGameMapSO;
        private GameMapBase currentMap;
        private GameInputHandler gameInputHandler;
        private EnemySpawnHandler enemySpawnHandler;
        private InGameplayCameraHandler inGameplayCameraHandler;


        protected override void OnEnable()
        {
            base.OnEnable();
            GameEvents.MainMenuEvents.OnGameMapSelected += OnGameMapSelected;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.MainMenuEvents.OnGameMapSelected -= OnGameMapSelected;
        }

        public async void LoadGameMap()
        {
            var map = ObjectPoolManager.Instance.PullPrefab<GameMapBase>(UID: currentGameMapSO.UID);
            await map;
            currentMap = map.Result;
            GameEvents.GameplayEvents.OnGameMapSpawned?.Invoke(currentMap);
        }

        public void UnLoadGameMap()
        {
            if (!currentMap) return;
            ObjectPoolManager.Instance.PushPrefab(currentMap, UID: currentGameMapSO.UID);
            GameEvents.GameplayEvents.OnGameMapUnSpawned?.Invoke();
        }

        public async void LoadGameInputHandler()
        {
            var handler = ObjectPoolManager.Instance.PullPrefab<GameInputHandler>(parent: transform);
            await handler;
            gameInputHandler = handler.Result;
        }

        public void UnLoadGameInputHandler()
        {
            if (!gameInputHandler) return;
            ObjectPoolManager.Instance.PushPrefab(gameInputHandler);
        }

        public async void LoadEnemySpawnHandler()
        {
            var handler = ObjectPoolManager.Instance.PullPrefab<EnemySpawnHandler>(parent: transform);
            await handler;
            enemySpawnHandler = handler.Result;
        }

        public void UnLoadEnemySpawnHandler()
        {
            if (!enemySpawnHandler) return;
            ObjectPoolManager.Instance.PushPrefab(enemySpawnHandler);
        }

        public async void LoadInGameplayCameraHandler()
        {
            var handler = ObjectPoolManager.Instance.PullPrefab<InGameplayCameraHandler>(parent: transform);
            await handler;
            inGameplayCameraHandler = handler.Result;
        }

        public void UnLoadInGameplayCameraHandler()
        {
            if (!inGameplayCameraHandler) return;
            ObjectPoolManager.Instance.PushPrefab(inGameplayCameraHandler);
        }

        #region Events
        private void OnGameMapSelected(GameMapSO data)
        {
            currentGameMapSO = data;
        }

        #endregion
    }
}
