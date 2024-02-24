using StrategyGame.Events;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Window.MainMenuWindow
{
    public class MapSelectItem : MonoBehaviour, IObjectPoolItem, IUIDTOProvider<GameMapSO>
    {
        [SerializeField] private Button button;
        private GameMapSO gameMapSO;
        public void SetUIObjectData(GameMapSO uiData)
        {
            gameMapSO = uiData;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected?.Invoke(gameMapSO);
        }
    }
}
