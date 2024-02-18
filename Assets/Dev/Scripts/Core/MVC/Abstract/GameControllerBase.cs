using StrategyGame.GameCore.CoreStates;

namespace StrategyGame.GameCore.MVC
{
    public abstract class GameControllerBase<T> : MVCBase<T> where T: IMVCDriver
    {

    }
}
