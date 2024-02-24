using StrategyGame.Events;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StrategyGame.Gameplay.Building
{
    public abstract class BuildingBase : MonoBehaviour, IObjectPoolItem, IPointerClickHandler
    {
        public BuildingSO BuildingSO { get; private set; }
        private bool isPlacementSequenceStarted;

        public void Initialize(BuildingSO buildingSO)
        {
            BuildingSO = buildingSO;
        }

        protected virtual void OnEnable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted += OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded += OnBuildingPlacementEnded;
        }

        protected virtual void OnDisable()
        {
            GameEvents.GameplayEvents.OnBuildingPlacementStarted -= OnBuildingPlacementStarted;
            GameEvents.GameplayEvents.OnBuildingPlacementEnded -= OnBuildingPlacementEnded;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isPlacementSequenceStarted) return;
            Debug.Log("Building Clicked");
            GameEvents.GameplayEvents.OnPlacedBuildingClicked?.Invoke(this);
        }

        #region Events
        private void OnBuildingPlacementStarted()
        {
            isPlacementSequenceStarted = true;
        }

        private void OnBuildingPlacementEnded()
        {
            isPlacementSequenceStarted = false;
        }
        #endregion
    }
}
