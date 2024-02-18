using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Management.SceneManagement
{
    [CreateAssetMenu(fileName = nameof(AllSceneSO), menuName = "StrategyGame/Scene/" + nameof(AllSceneSO))]
    public class AllSceneSO : GameBaseSO
    {
        public List<SceneSO> AllSceneList;
    }
}
