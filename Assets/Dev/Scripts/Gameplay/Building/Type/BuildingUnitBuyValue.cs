using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.UI;

namespace StrategyGame.Gameplay.Building
{
    public struct BuildingUnitBuyValue: IUIDTO
    {
        public BuildingBase Building;
        public ProduceUnitBaseSO ProduceUnitSO;
    }
}
