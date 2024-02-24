using StrategyGame.ScriptableScripts;
using StrategyGame.UI;
using UnityEngine;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    [CreateAssetMenu(fileName = nameof(ProduceUnitSO), menuName = "StrategyGame/Gameplay/Building/ProduceUnit/" + nameof(ProduceUnitSO))]
    public class ProduceUnitSO : AssetReferenceBaseSO
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}
