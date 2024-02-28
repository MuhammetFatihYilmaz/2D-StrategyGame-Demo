using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.CameraMovement
{
    public abstract class CameraMovementInputBase : MonoBehaviour
    {
        protected abstract void SetCameraMovementInput();
        protected RuntimeCameraMovementInputDataSO RuntimeCameraMovementInputDataSO { get; private set; }
        protected CameraMovementInputValue CameraMovementInputValue { get; private set; }

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            RuntimeCameraMovementInputDataSO = allRuntimeInputDataSO.RuntimeCameraMovementInputDataSO;
            RuntimeCameraMovementInputDataSO.ResetData();
        }

        private void Update()
        {
            SetCameraMovementInput();
        }

        public void Initialize(CameraMovementInputValue cameraMovementInputValue)
        {
            CameraMovementInputValue = cameraMovementInputValue;
        }

        protected void ClampMovementValue()
        {
            RuntimeCameraMovementInputDataSO.CameraPosition.x = Mathf.Clamp(RuntimeCameraMovementInputDataSO.CameraPosition.x, -CameraMovementInputValue.MaxHorizontalValue, CameraMovementInputValue.MaxHorizontalValue);
            RuntimeCameraMovementInputDataSO.CameraPosition.y = Mathf.Clamp(RuntimeCameraMovementInputDataSO.CameraPosition.y, -CameraMovementInputValue.MaxVerticalValue, CameraMovementInputValue.MaxVerticalValue);
        }
    }
}
