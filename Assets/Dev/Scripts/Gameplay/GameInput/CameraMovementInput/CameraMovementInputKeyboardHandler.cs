using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.CameraMovement
{
    public class CameraMovementInputKeyboardHandler : CameraMovementInputBase
    {
        protected override void SetCameraMovementInput()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                RuntimeCameraMovementInputDataSO.CameraPosition += Vector2.up * CameraMovementInputValue.CameraMovementSpeed;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                RuntimeCameraMovementInputDataSO.CameraPosition += Vector2.up * (-CameraMovementInputValue.CameraMovementSpeed);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                RuntimeCameraMovementInputDataSO.CameraPosition += Vector2.right * CameraMovementInputValue.CameraMovementSpeed;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                RuntimeCameraMovementInputDataSO.CameraPosition += Vector2.right * (-CameraMovementInputValue.CameraMovementSpeed);

            ClampMovementValue();
        }
    }
}
