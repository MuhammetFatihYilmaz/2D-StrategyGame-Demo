using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StrategyGame.Gameplay.Building;
using StrategyGame.Events;

namespace StrategyGame.UI.Window.InGameplayWindow
{
    public class UnitBuyItem : MonoBehaviour, IObjectPoolItem, IUIDTOProvider<BuildingUnitBuyValue>
    {
        [SerializeField] private Button unitBuyButton;
        [SerializeField] private Image unitImage;
        [SerializeField] private TextMeshProUGUI unitNameText;
        private BuildingBase building;
        private ProduceUnitBaseSO produceUnitSO;


        public void SetUIObjectData(BuildingUnitBuyValue uiData)
        {
            unitBuyButton.onClick.RemoveAllListeners();
            unitBuyButton.onClick.AddListener(OnClick);
            building = uiData.Building;
            produceUnitSO = uiData.ProduceUnitSO;
            unitImage.sprite = produceUnitSO.Icon;
            unitNameText.text = produceUnitSO.Name;
        }

        private void OnClick()
        {
            GameEvents.GameplayEvents.OnUnitBuyClicked?.Invoke(building, produceUnitSO);
        }
    }
}
