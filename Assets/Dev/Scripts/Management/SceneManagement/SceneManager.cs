using StrategyGame.Management.ObjectPoolManagement;
using System.Collections;
using UnityEngine;

namespace StrategyGame.Management.SceneManagement
{
    public class SceneManager : ManagerBase
    {
        private AllSceneSO allSceneSO;
        private SceneSO currentScene;

        protected override IEnumerator InitSequence()
        {
            Debug.Log("Scene Manager Init");
            allSceneSO = ObjectPoolManager.Instance.PullScriptable<AllSceneSO>();
            currentScene = allSceneSO.AllSceneList.Find(x => x.SceneType == SceneType.Init);
            yield return new WaitForEndOfFrame();
        }

        public void LoadScene(SceneType sceneType)
        {
            var sceneSO = allSceneSO.AllSceneList.Find(x => x.SceneType == sceneType);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneSO.BuildIndex);
            currentScene = sceneSO;
        }
    }
}
