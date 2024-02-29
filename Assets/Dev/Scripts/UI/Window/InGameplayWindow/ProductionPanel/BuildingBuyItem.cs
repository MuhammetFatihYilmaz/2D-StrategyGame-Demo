using StrategyGame.Events;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StrategyGame.Gameplay.Building;

namespace StrategyGame.UI.Window.InGameplayWindow.Production
{
    public class BuildingBuyItem : MonoBehaviour,IObjectPoolItem ,IUIDTOProvider<BuildingSO>
    {
        [SerializeField] private Button buildingBuyButton;
        [SerializeField] private TextMeshProUGUI buildingNameText;
        [SerializeField] private Image buildingImage;
        [SerializeField] private TextMeshProUGUI buildingSizeText;
        private BuildingSO buildingSO;

        public void SetUIObjectData(BuildingSO uiData)
        {
            buildingNameText.text = uiData.Name;
            buildingImage.sprite = uiData.Icon;
            buildingSO = uiData;
            buildingSizeText.text = uiData.Size.ToString();
            buildingBuyButton.onClick.RemoveAllListeners();
            buildingBuyButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameEvents.GameplayEvents.OnBuildingBuyItemClicked?.Invoke(buildingSO);
        }
    }
}
