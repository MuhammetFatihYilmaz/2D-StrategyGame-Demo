using StrategyGame.Gameplay.Building.ProduceUnit;
using StrategyGame.ScriptableScripts;
using StrategyGame.UI;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Building
{
    [CreateAssetMenu(fileName = nameof(BuildingSO), menuName = "StrategyGame/Gameplay/Building/" + nameof(BuildingSO))]
    public class BuildingSO : AssetReferenceBaseSO, IUIDTO
    {
        [field: SerializeField] public BuildingType BuildingType { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Vector2Int Size { get; private set; } = Vector2Int.one;
        [field: SerializeField] public List<ProduceUnitSO> ProduceUnitList { get; private set; }
    }
}
