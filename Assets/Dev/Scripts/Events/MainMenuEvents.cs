using StrategyGame.Gameplay.GameMap;
using System;

namespace StrategyGame.Events
{
    public static partial class GameEvents
    {
        public static class MainMenuEvents
        {
            public static Action OnStartGameButtonClicked;
            public static Action OnExitGameButtonClicked;
            public static Action<GameMapSO> OnGameMapSelected;
        }
    }
}
