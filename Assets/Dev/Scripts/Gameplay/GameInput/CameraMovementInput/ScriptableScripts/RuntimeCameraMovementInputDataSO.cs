using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.CameraMovement
{
    [CreateAssetMenu(fileName = nameof(RuntimeCameraMovementInputDataSO), menuName = "StrategyGame/Gameplay/GameInput/" + nameof(RuntimeCameraMovementInputDataSO))]
    public class RuntimeCameraMovementInputDataSO : GameBaseSO
    {
        public Vector2 CameraPosition;

        public void ResetData()
        {
            CameraPosition = Vector2.zero;
        }
    }
}
