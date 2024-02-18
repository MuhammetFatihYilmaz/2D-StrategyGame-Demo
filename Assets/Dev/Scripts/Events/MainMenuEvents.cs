using System;

namespace StrategyGame.Events
{
    public static partial class GameEvents
    {
        public static class MainMenuEvents
        {
            public static Action OnStartGameButtonClicked;
            public static Action OnExitGameButtonClicked;
        }
    }
}
