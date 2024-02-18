using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Management.SceneManagement
{
    [CreateAssetMenu(fileName = nameof(SceneSO), menuName = "StrategyGame/Scene/" + nameof(SceneSO))]
    public class SceneSO : GameBaseSO
    {
        [field: SerializeField] public SceneType SceneType { get; private set; }
        [field: SerializeField] public int BuildIndex { get; private set; }
    }
}
