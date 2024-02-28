using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameInput.CameraMovement;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.InGameplayCamera
{
    public class InGameplayCameraHandler : MonoBehaviour, IObjectPoolItem
    {
        private RuntimeCameraMovementInputDataSO runtimeCameraMovementInputDataSO;

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            runtimeCameraMovementInputDataSO = allRuntimeInputDataSO.RuntimeCameraMovementInputDataSO;
        }

        private void LateUpdate()
        {
            transform.position = runtimeCameraMovementInputDataSO.CameraPosition;
        }
    }
}
