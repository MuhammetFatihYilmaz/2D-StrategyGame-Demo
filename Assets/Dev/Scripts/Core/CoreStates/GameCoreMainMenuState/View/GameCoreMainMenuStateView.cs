using StrategyGame.GameCore.MVC;
using StrategyGame.UI.Window.MainMenuWindow;

namespace StrategyGame.GameCore.CoreStates.MainMenuState
{
    public class GameCoreMainMenuStateView : GameViewBase<GameCoreMainMenuState>
    {
        public async void LoadMainMenuWindow()
        {
            var task = LoadWindow<MainMenuWindow>();
            await task;
        }

        public void UnLoadMainMenuWindow()
        {
            UnLoadWindow<MainMenuWindow>();
        }
    }
}
