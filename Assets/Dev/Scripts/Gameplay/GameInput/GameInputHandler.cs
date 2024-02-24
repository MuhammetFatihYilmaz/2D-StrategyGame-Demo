using StrategyGame.Gameplay.GameInput.Placement;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput
{
    public class GameInputHandler : MonoBehaviour, IObjectPoolItem
    {
        private void Awake()
        {
            InitializePlacementInput();
        }

        private void InitializePlacementInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<PlacementInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<PlacementInputKeyboardHandler>();
#endif
        }
    }
}
