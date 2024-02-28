using StrategyGame.Gameplay.Health;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using TMPro;

namespace StrategyGame.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour, IObjectPoolItem, ITakeDamage
    {
        [SerializeField] private TMP_Text healthText;
        private int currentHealth;
        private EnemySO enemySO;
        public void Initialize(EnemySO enemySO)
        {
            this.enemySO = enemySO;
            currentHealth = enemySO.Health;
            healthText.text = currentHealth.ToString();
        }
        public void TakeDamage(DamageBase damage)
        {
            if (enemySO.ResistanceDamageType == damage.GivenDamageType)
                currentHealth -= (damage.DamageAmount / 2);
            else
                currentHealth -= damage.DamageAmount;

            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
                ObjectPoolManager.Instance.PushPrefab(this, UID: enemySO.UID);
        }
    }
}
