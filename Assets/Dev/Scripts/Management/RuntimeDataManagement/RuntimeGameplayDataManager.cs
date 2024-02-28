using StrategyGame.Events;
using StrategyGame.Gameplay.GameMap;
using System.Collections;

namespace StrategyGame.Management.RuntimeGameplayDataManagement
{
    public class RuntimeGameplayDataManager : ManagerBase
    {
        private GameMapBase currentSelectedMap;
        protected override IEnumerator InitSequence()
        {
            yield break;
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned += OnGameMapSpawned;
            GameEvents.GameplayEvents.OnGameMapUnSpawned += OnGameMapUnSpawned;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned -= OnGameMapSpawned;
            GameEvents.GameplayEvents.OnGameMapUnSpawned -= OnGameMapUnSpawned;
        }

        public GameMapBase GetCurrentMap() => currentSelectedMap;

        #region Events
        private void OnGameMapSpawned(GameMapBase map)
        {
            currentSelectedMap = map;
        }

        private void OnGameMapUnSpawned()
        {
            currentSelectedMap = default;
        }
        #endregion
    }
}
