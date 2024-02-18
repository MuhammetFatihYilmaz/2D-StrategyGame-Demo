using StrategyGame.GameCore.CoreStates;
using StrategyGame.GameCore.CoreStates.InitState;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.GameCore
{
    public class GameCore : MonoBehaviour, IStateDriver
    {
        [SerializeField] private List<CoreStateBase> gameCoreStates = new();
        [SerializeField] private CoreStateCommonValue coreStateCommonValue;

        private CoreStateBase currentState;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            RegisterStates();
            SwitchState<GameCoreInitState>();
        }

        public void SwitchState<T>() where T : IState
        {
            var state = gameCoreStates.Find(x => x.GetType() == typeof(T));
            if (state == null) return;

            currentState?.OnUnSet();
            currentState = state;
            currentState.OnSet();
        }

        public void RegisterStates()
        {
            foreach (var state in gameCoreStates)
            {
                state.SetStateDriver(this);
                state.SetCommonValues(coreStateCommonValue);
            }
        }
    }
}
