using StrategyGame.GameCore.MVC;
using StrategyGame.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.InitState
{
    public class GameCoreInitStateController : GameControllerBase<GameCoreInitState>
    {
        [SerializeField] private List<ManagerBase> managers;
        public IEnumerator InitManagers()
        {
            foreach (var manager in managers)
            {
                MVCDriver.CommonValue.LoadingWindow.StartLoadingTask(new WaitUntil(()=>manager.IsManagerInitialized));
                yield return manager.InitManager();
            }
        }
    }
}
