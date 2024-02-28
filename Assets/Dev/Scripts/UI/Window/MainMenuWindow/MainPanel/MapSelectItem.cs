using StrategyGame.Events;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace StrategyGame.UI.Window.MainMenuWindow
{
    public class MapSelectItem : MonoBehaviour, IObjectPoolItem, IUIDTOProvider<GameMapSO>
    {
        [SerializeField] private Button button;
        [SerializeField] private Image mapSelectItemImage;
        [SerializeField] private TextMeshProUGUI mapSelectItemText;
        private GameMapSO gameMapSO;
        public void SetUIObjectData(GameMapSO uiData)
        {
            gameMapSO = uiData;
            mapSelectItemImage.sprite = gameMapSO.Icon;
            mapSelectItemText.text = gameMapSO.Name;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameEvents.MainMenuEvents.OnGameMapSelected?.Invoke(gameMapSO);
        }
    }
}
