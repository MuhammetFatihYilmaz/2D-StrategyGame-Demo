namespace StrategyGame.GameCore.CoreStates
{
    public interface IState
    {
        void SetStateDriver(IStateDriver stateDriver);
        void SetCommonValues(IStateCommonValue commonValue);
    }
}
