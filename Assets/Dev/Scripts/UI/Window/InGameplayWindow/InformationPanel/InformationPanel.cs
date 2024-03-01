using StrategyGame.Events;
using StrategyGame.Gameplay.Building;
using StrategyGame.Management.ObjectPoolManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace StrategyGame.UI.Window.InGameplayWindow.Information
{
    public class InformationPanel : UIDisplayBase
    {
        [SerializeField] private Button hideButton;
        [SerializeField] private Transform unitBuyItemContainer;
        [SerializeField] private Image buildingImage;
        [SerializeField] private TextMeshProUGUI buildingText;
        [SerializeField] private Button destroyBuildingButton;
        [SerializeField] private GameObject unitTextGameObject;

        private List<UnitBuyItem> currentUnitBuyItemList = new(); 
        private BuildingBase currentSelectedBuilding;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            hideButton.onClick.AddListener(Hide);
            destroyBuildingButton.onClick.AddListener(DestroyBuilding);
            GameEvents.GameplayEvents.OnPlacedBuildingClicked += OnPlacedBuildingClicked;
            GameEvents.GameplayEvents.OnSettingsMainMenuButtonClicked += OnSettingsMainMenuButtonClicked;
        }

        private void OnDisable()
        {
            hideButton.onClick.RemoveListener(Hide);
            destroyBuildingButton.onClick.RemoveListener(DestroyBuilding);
            GameEvents.GameplayEvents.OnPlacedBuildingClicked -= OnPlacedBuildingClicked;
            GameEvents.GameplayEvents.OnSettingsMainMenuButtonClicked -= OnSettingsMainMenuButtonClicked;
        }

        private void SetInformationValues()
        {
            if (!currentSelectedBuilding) return;
            if (!currentSelectedBuilding.BuildingSO) return;

            buildingImage.sprite = currentSelectedBuilding.BuildingSO.Icon;
            buildingText.text = currentSelectedBuilding.BuildingSO.Name;
            destroyBuildingButton.gameObject.SetActive(true);

            if (currentSelectedBuilding.BuildingSO.BuildingType == BuildingType.Producible)
            {
                unitTextGameObject.SetActive(true);
                unitBuyItemContainer.gameObject.SetActive(true);
                CreateUnitBuyItem();
            }
            else if (currentSelectedBuilding.BuildingSO.BuildingType == BuildingType.NonProducible)
            {
                unitTextGameObject.SetActive(false);
                unitBuyItemContainer.gameObject.SetActive(false);
            }
        }

        private void ResetInformationValues()
        {
            if (currentSelectedBuilding.BuildingSO.BuildingType == BuildingType.Producible)
            {
                unitTextGameObject.SetActive(false);
                unitBuyItemContainer.gameObject.SetActive(false);
            }
            destroyBuildingButton.gameObject.SetActive(false);
            currentSelectedBuilding = default;
            buildingImage.sprite = default;
            buildingText.text = "";
        }

        private async void CreateUnitBuyItem()
        {
            if(currentUnitBuyItemList.Any())
                currentUnitBuyItemList.ForEach(x => ObjectPoolManager.Instance.PushPrefab(x));

            foreach (var produceUnitSO in currentSelectedBuilding.BuildingSO.ProduceUnitList)
            {
                var task = ObjectPoolManager.Instance.PullPrefab<UnitBuyItem>(parent: unitBuyItemContainer);
                await task;
                task.Result.SetUIObjectData(new BuildingUnitBuyValue{Building = currentSelectedBuilding , ProduceUnitSO = produceUnitSO});
                currentUnitBuyItemList.Add(task.Result);
            }
        }

        private void DestroyBuilding()
        {
            if (!currentSelectedBuilding) return;
            GameEvents.GameplayEvents.OnBuildingDestroyed?.Invoke(currentSelectedBuilding);
            ResetInformationValues();
        }

        #region Events
        private void OnPlacedBuildingClicked(BuildingBase building)
        {
            Show();
            currentSelectedBuilding = building;
            SetInformationValues();
        }

        private void OnSettingsMainMenuButtonClicked()
        {
            Hide();
        }
        #endregion
    }
}
