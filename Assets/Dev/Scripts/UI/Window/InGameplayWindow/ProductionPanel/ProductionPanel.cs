using StrategyGame.Gameplay.Building;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.UI.Window.InGameplayWindow
{
    public class ProductionPanel : UIDisplayBase
    {
        [SerializeField] private Transform buildingBuyItemContainer;
        private AllBuildingSO allBuildingSO;

        protected override void Awake()
        {
            base.Awake();
            allBuildingSO = ObjectPoolManager.Instance.PullScriptable<AllBuildingSO>();
            CreateBuildingBuyItems();
        }

        private async void CreateBuildingBuyItems()
        {
            foreach (var building in allBuildingSO.AllBuildingSOList)
            {
                var task = ObjectPoolManager.Instance.PullPrefab<BuildingBuyItem>(parent: buildingBuyItemContainer);
                await task;
                task.Result.SetUIObjectData(building);
            }
        }
    }
}
