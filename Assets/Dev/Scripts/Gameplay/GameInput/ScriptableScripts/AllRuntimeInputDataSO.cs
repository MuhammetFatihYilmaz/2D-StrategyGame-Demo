using StrategyGame.Gameplay.GameInput.Placement;
using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput
{
    [CreateAssetMenu(fileName = nameof(AllRuntimeInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(AllRuntimeInputDataSO))]
    public class AllRuntimeInputDataSO : GameBaseSO
    {
        [field: SerializeField] public RuntimePlacementInputDataSO RuntimePlacementInputDataSO { get; private set; }
    }
}
