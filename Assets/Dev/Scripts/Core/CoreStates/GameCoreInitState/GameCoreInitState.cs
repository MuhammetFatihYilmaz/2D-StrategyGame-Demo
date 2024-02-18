using StrategyGame.GameCore.CoreStates.MainMenuState;
using StrategyGame.GameCore.MVC;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.Management.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates.InitState
{
    public class GameCoreInitState : CoreStateBase
    {
        [SerializeField] private GameCoreInitStateController gameCoreInitStateController;
        protected override void Awake()
        {
            base.Awake();
        }

        protected override IEnumerable<IMVC> ApplyMVCValues()
        {
            yield return gameCoreInitStateController;
        }

        public override void OnSet()
        {
            Debug.Log("GameCoreInitState Onset");
            StartCoroutine(Initialize());
        }

        public override void OnUnSet()
        {
            Debug.Log("GameCoreInitState Unset");
        }

        private IEnumerator Initialize()
        {
            yield return gameCoreInitStateController.InitManagers();
            ObjectPoolManager.Instance.PullManager<SceneManager>().LoadScene(sceneType: SceneType.Menu);
            StateDriver.SwitchState<GameCoreMainMenuState>();
        }
    }
}
