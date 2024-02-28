using StrategyGame.Gameplay.Health;
using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    public abstract class ProduceUnitBaseSO : AssetReferenceBaseSO
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public DamageType ResistanceDamageType { get; private set; }
    }
}
