namespace StrategyGame.UI
{
    public interface IUIDTOProvider<T> where T: IUIDTO
    {
        void SetUIObjectData(T uiData);
    }
}
