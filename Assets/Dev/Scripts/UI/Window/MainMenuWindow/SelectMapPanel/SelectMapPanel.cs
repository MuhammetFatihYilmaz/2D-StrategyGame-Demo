using StrategyGame.Events;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.UI.Window.MainMenuWindow.MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Window.MainMenuWindow.SelectMap
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

        private void OnEnable()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected += OnGameMapSelected;
        }

        private void OnDisable()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected -= OnGameMapSelected;
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

        #region Events
        private void OnGameMapSelected(GameMapSO map)
        {
            Hide();
        }
        #endregion
    }
}
