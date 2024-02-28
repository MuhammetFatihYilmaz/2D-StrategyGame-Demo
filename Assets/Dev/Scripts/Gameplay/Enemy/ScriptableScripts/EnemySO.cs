using StrategyGame.Gameplay.Health;
using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = nameof(EnemySO), menuName = "StrategyGame/Gameplay/Enemy/" + nameof(EnemySO))]
    public class EnemySO : AssetReferenceBaseSO
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public DamageType ResistanceDamageType { get; private set; }
    }
}
