using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Window.MainMenuWindow
{
    public class SelectMapPanel : UIDisplayBase
    {
        [SerializeField] private Transform selectMapItemContainer;
        [SerializeField] private Button hideButton;
        private AllGameMapSO allGameMapSO;
        protected override void Awake()
        {
            base.Awake();
            hideButton.onClick.AddListener(Hide);
            allGameMapSO = ObjectPoolManager.Instance.PullScriptable<AllGameMapSO>();
            CreateSelectMapItems();
        }

        private async void CreateSelectMapItems()
        {
            foreach (var map in allGameMapSO.GameMapSOList)
            {
                var task = ObjectPoolManager.Instance.PullPrefab<MapSelectItem>(parent: selectMapItemContainer);
                await task;
                task.Result.SetUIObjectData(map);
            }
        }
    }
}
