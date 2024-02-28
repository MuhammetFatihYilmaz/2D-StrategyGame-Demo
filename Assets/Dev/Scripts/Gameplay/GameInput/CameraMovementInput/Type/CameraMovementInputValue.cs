using UnityEngine;

namespace StrategyGame.Gameplay.GameInput.CameraMovement
{
    [System.Serializable]
    public struct CameraMovementInputValue
    {
        [field: SerializeField] public float CameraMovementSpeed { get; set; }
        public float MaxHorizontalValue { get; set; }
        public float MaxVerticalValue { get; set; }
    }
}
