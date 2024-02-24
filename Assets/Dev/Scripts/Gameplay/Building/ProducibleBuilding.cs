using StrategyGame.Events;
using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.Management.ObjectPoolManagement;

namespace StrategyGame.Gameplay.Building
{
    public class ProducibleBuilding : BuildingBase
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            GameEvents.GameplayEvents.OnUnitBuyClicked += OnUnitBuyClicked;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.GameplayEvents.OnUnitBuyClicked -= OnUnitBuyClicked;
        }


        #region Events

        private async void OnUnitBuyClicked(BuildingBase building, ProduceUnitSO produceUnitSO)
        {
            if (building != this) return;
            var unit = ObjectPoolManager.Instance.PullPrefab<ProduceUnitBase>(UID: produceUnitSO.UID);
            await unit;
        }
        #endregion

    }
}
