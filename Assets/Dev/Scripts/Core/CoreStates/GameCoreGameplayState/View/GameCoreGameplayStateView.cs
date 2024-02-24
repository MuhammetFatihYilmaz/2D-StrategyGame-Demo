using StrategyGame.GameCore.MVC;
using StrategyGame.UI.Window.InGameplayWindow;

namespace StrategyGame.GameCore.CoreStates.GameplayState
{
    public class GameCoreGameplayStateView : GameViewBase<GameCoreGameplayState>
    {
        public async void LoadInGameplayWindow()
        {
            var task = LoadWindow<InGameplayWindow>();
            await task;
        }

        public void UnLoadInGameplayWindow()
        {
            UnLoadWindow<InGameplayWindow>();
        }
    }
}
