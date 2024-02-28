using StrategyGame.Gameplay.Health;
using UnityEngine;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    [CreateAssetMenu(fileName = nameof(AttackableProduceUnitSO), menuName = "StrategyGame/Gameplay/Building/ProduceUnit/" + nameof(AttackableProduceUnitSO))]
    public class AttackableProduceUnitSO : ProduceUnitBaseSO
    {
        [field: SerializeField] public DamageType GivenDamageType { get; private set; }
        [field: SerializeField] public int DamageAmount { get; private set; }

    }
}
