using StrategyGame.Events;
using StrategyGame.Gameplay.Health;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    public abstract class ProduceUnitBase : MonoBehaviour, IObjectPoolItem, IPointerClickHandler, ITakeDamage
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private ProduceUnitAttackController produceUnitAttackController;
        protected ProduceUnitBaseSO ProduceUnitSO;
        private int currentHealth;
        private DamageType resistanceDamageType;

        protected virtual void Awake()
        {

        }

        protected virtual void OnEnable()
        {

        }

        protected virtual void OnDisable()
        {

        }

        public void Initialize(ProduceUnitBaseSO produceUnitSO)
        {
            ProduceUnitSO = produceUnitSO;
            currentHealth = ProduceUnitSO.Health;
            resistanceDamageType = ProduceUnitSO.ResistanceDamageType;
            produceUnitAttackController?.Initialize(ProduceUnitSO);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameEvents.GameplayEvents.OnProduceUnitClicked?.Invoke(this);
        }

        public void TakeDamage(DamageBase damage)
        {
            if (damage.GivenDamageType == resistanceDamageType)
                currentHealth -= (damage.DamageAmount / 2);
            else
                currentHealth -= damage.DamageAmount;

            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
                ObjectPoolManager.Instance.PushPrefab(this, UID: ProduceUnitSO.UID);
        }
    }
}
