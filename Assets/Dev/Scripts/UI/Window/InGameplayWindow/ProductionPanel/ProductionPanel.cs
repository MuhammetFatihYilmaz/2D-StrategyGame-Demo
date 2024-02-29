using StrategyGame.Gameplay.Building;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.UI.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.UI.Window.InGameplayWindow
{
    public class ProductionPanel : UIDisplayBase
    {
        [SerializeField] private Transform buildingBuyItemContainer;
        [SerializeField] private InfiniteScroll infiniteScroll;
        private AllBuildingSO allBuildingSO;
        private List<RectTransform> buildingBuyItemRectList = new();


        protected override void Awake()
        {
            base.Awake();
            allBuildingSO = ObjectPoolManager.Instance.PullScriptable<AllBuildingSO>();
            CreateBuildingBuyItems();
        }

        private async void CreateBuildingBuyItems()
        {
            buildingBuyItemRectList.Clear();
            foreach (var building in allBuildingSO.AllBuildingSOList)
            {
                var task = ObjectPoolManager.Instance.PullPrefab<BuildingBuyItem>(parent: buildingBuyItemContainer);
                await task;
                task.Result.SetUIObjectData(building);
                buildingBuyItemRectList.Add(task.Result.GetComponent<RectTransform>());
            }
            infiniteScroll.Initialize(buildingBuyItemRectList);
        }
    }
}
