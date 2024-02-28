using StrategyGame.Gameplay.GameInput.CameraMovement;
using StrategyGame.Gameplay.GameInput.Placement;
using StrategyGame.Gameplay.GameInput.UnitAttacking;
using StrategyGame.Gameplay.GameInput.UnitMovement;
using StrategyGame.Gameplay.GameInput.UnitSpawn;
using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput
{
    [CreateAssetMenu(fileName = nameof(AllGameRuntimeInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(AllGameRuntimeInputDataSO))]
    public class AllGameRuntimeInputDataSO : GameBaseSO
    {
        [field: SerializeField] public RuntimePlacementInputDataSO RuntimePlacementInputDataSO { get; private set; }
        [field: SerializeField] public RuntimeUnitMovementInputDataSO RuntimeUnitMovementInputDataSO { get; private set; }
        [field: SerializeField] public RuntimeUnitSpawnInputDataSO RuntimeUnitSpawnInputDataSO { get; private set; }
        [field: SerializeField] public RuntimeUnitAttackingInputDataSO RuntimeUnitAttackingInputDataSO { get; private set; }
        [field: SerializeField] public RuntimeCameraMovementInputDataSO RuntimeCameraMovementInputDataSO { get; private set; }
    }
}
