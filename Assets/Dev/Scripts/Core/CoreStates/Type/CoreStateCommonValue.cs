using StrategyGame.Gameplay.GameMap;
using StrategyGame.UI.Window.LoadingWindow;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates
{
    [System.Serializable]
    public struct CoreStateCommonValue : IStateCommonValue
    {
        public LoadingWindow LoadingWindow;
    }
}
