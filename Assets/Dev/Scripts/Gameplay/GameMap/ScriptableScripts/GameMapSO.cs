using StrategyGame.ScriptableScripts;
using StrategyGame.UI;
using UnityEngine;


namespace StrategyGame.Gameplay.GameMap
{
    [CreateAssetMenu(fileName = nameof(GameMapSO), menuName = "StrategyGame/Gameplay/GameMap/" + nameof(GameMapSO))]
    public class GameMapSO: AssetReferenceBaseSO, IUIDTO
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}
