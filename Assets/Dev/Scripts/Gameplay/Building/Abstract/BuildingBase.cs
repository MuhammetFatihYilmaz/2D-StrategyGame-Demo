using StrategyGame.Events;
using StrategyGame.Gameplay.Health;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

namespace StrategyGame.Gameplay.Building
{
    public abstract class BuildingBase : MonoBehaviour, IObjectPoolItem, IPointerClickHandler, ITakeDamage
    {
        public BuildingSO BuildingSO { get; private set; }
        [SerializeField] private TMP_Text healthText;

        private bool isIndicatorSequenceStarted;
        private int currentHealth;

        protected virtual void Awake()
        {

        }

        protected virtual void OnEnable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted += OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded += OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted += OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded += OnUnitSpawnSequenceEnded;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingStarted += OnProduceUnitAttackDetectingStarted;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingEnded += OnProduceUnitAttackDetectingEnded;
        }

        protected virtual void OnDisable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted -= OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded -= OnBuildingPlacementEnded;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceStarted -= OnUnitSpawnSequenceStarted;
            GameEvents.GameplayEvents.OnUnitSpawnSequenceEnded -= OnUnitSpawnSequenceEnded;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingStarted -= OnProduceUnitAttackDetectingStarted;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingEnded -= OnProduceUnitAttackDetectingEnded;
        }

        public void Initialize(BuildingSO buildingSO)
        {
            BuildingSO = buildingSO;
            currentHealth = buildingSO.Health;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isIndicatorSequenceStarted) return;
            Debug.Log("Building Clicked");
            GameEvents.GameplayEvents.OnPlacedBuildingClicked?.Invoke(this);
        }

        public void TakeDamage(DamageBase damage)
        {
            currentHealth -= damage.DamageAmount;
            healthText.text = currentHealth.ToString();

            if (currentHealth <= 0)
                ObjectPoolManager.Instance.PushPrefab(this, UID: BuildingSO.UID);
        }

        #region Events
        private void OnBuildingPlacementStarted()
        {
            isIndicatorSequenceStarted = true;
        }

        private void OnBuildingPlacementEnded()
        {
            isIndicatorSequenceStarted = false;
        }

        private void OnUnitSpawnSequenceStarted()
        {
            isIndicatorSequenceStarted = true;
        }

        private void OnUnitSpawnSequenceEnded()
        {
            isIndicatorSequenceStarted = false;
        }


        private void OnProduceUnitAttackDetectingStarted()
        {
            isIndicatorSequenceStarted = true;
        }

        private void OnProduceUnitAttackDetectingEnded()
        {
            isIndicatorSequenceStarted = false;
        }
        #endregion
    }
}
