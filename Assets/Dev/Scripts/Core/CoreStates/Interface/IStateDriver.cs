namespace StrategyGame.GameCore.CoreStates
{
    public interface IStateDriver
    {
        void RegisterStates();
        void SwitchState<T>() where T: IState;
    }
}
