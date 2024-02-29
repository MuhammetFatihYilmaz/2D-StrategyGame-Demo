using StrategyGame.Events;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace StrategyGame.Gameplay.Enemy
{
    public class EnemySpawnHandler : MonoBehaviour, IObjectPoolItem
    {
        private AllEnemySO allEnemySO;
        private int randomEnemySOIndex;
        private Vector2 enemySpawnPos;
        private int gridSizeX;
        private int gridSizeY;

        private List<Vector2> enemySpawnedPosList = new();

        private void Awake()
        {
            allEnemySO = ObjectPoolManager.Instance.PullScriptable<AllEnemySO>();
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned += OnGameMapSpawned;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned -= OnGameMapSpawned;
        }

        private IEnumerator SpawnSequence(GameMapBase map)
        {
            enemySpawnedPosList.Clear();
            gridSizeX = map.Grid.GridSizeX / 2;
            gridSizeY = map.Grid.GridSizeY / 2;

            for (int i = 0; i < 20; i++)
            {
                enemySpawnPos.x = Random.Range(-gridSizeX, gridSizeX);
                enemySpawnPos.y = Random.Range(-gridSizeY, gridSizeY);

                while (enemySpawnedPosList.Contains(enemySpawnPos))
                {
                    enemySpawnPos.x = Random.Range(-gridSizeX, gridSizeX);
                    enemySpawnPos.y = Random.Range(-gridSizeY, gridSizeY);
                    yield return new WaitForEndOfFrame();
                }

                enemySpawnedPosList.Add(enemySpawnPos);

                randomEnemySOIndex = Random.Range(0, allEnemySO.AllEnemySOList.Count);

                Task enemyTask = CreateEnemy(randomEnemySOIndex);
                yield return new WaitUntil(() => enemyTask.IsCompleted);
            }
            GameEvents.GameplayEvents.OnEnemiesSpawnCompleted?.Invoke();
        }

        private async Task CreateEnemy(int randomEnemySOIndex)
        {
            var enemyTask = ObjectPoolManager.Instance.PullPrefab<EnemyController>(UID: allEnemySO.AllEnemySOList[randomEnemySOIndex].UID);
            await enemyTask;
            enemyTask.Result.Initialize(allEnemySO.AllEnemySOList[randomEnemySOIndex]);
            enemyTask.Result.transform.position = enemySpawnPos;
        }

        #region Events
        private void OnGameMapSpawned(GameMapBase map)
        {
            StartCoroutine(SpawnSequence(map));
        }
        #endregion
    }
}
