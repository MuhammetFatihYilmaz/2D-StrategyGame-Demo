using StrategyGame.Events;
using StrategyGame.Gameplay.GameInput.CameraMovement;
using StrategyGame.Gameplay.GameInput.Placement;
using StrategyGame.Gameplay.GameInput.UnitAttacking;
using StrategyGame.Gameplay.GameInput.UnitMovement;
using StrategyGame.Gameplay.GameInput.UnitSpawn;
using StrategyGame.Gameplay.GameMap;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.GameInput
{
    public class GameInputHandler : MonoBehaviour, IObjectPoolItem
    {
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private CameraMovementInputValue cameraMovementInputValue;

        private void Awake()
        {
            InitializePlacementInput();
            InitializeUnitSpawnInput();
            InitializeUnitMovementInput();
            InitializeUnitAttackingInput();
            InitializeCameraMovementInput();
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned += OnGameMapSpawned;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnGameMapSpawned -= OnGameMapSpawned;
        }

        private void InitializePlacementInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<PlacementInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<PlacementInputKeyboardHandler>();
#endif
        }

        private void InitializeUnitSpawnInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<UnitSpawnInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<UnitSpawnInputKeyboardHandler>();
#endif
        }

        private void InitializeUnitMovementInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<UnitMovementInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<UnitMovementInputKeyboardHandler>();
#endif

            GetComponent<UnitMovementInputBase>().Initialize(groundLayerMask);
        }

        private void InitializeUnitAttackingInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<UnitAttackingInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<UnitAttackingInputKeyboardHandler>();
#endif
        }

        private void InitializeCameraMovementInput()
        {
#if UNITY_EDITOR
            gameObject.AddComponent<CameraMovementInputKeyboardHandler>();
#elif UNITY_STANDALONE
            gameObject.AddComponent<CameraMovementInputKeyboardHandler>();
#endif
            
        }

        private void SetCameraMovementInputValue(GameMapBase map)
        {
            cameraMovementInputValue.MaxHorizontalValue = map.Grid.GridSizeX / 2;
            cameraMovementInputValue.MaxVerticalValue = map.Grid.GridSizeY / 2;
            GetComponent<CameraMovementInputKeyboardHandler>().Initialize(cameraMovementInputValue);
        }

        #region Events
        private void OnGameMapSpawned(GameMapBase map)
        {
            SetCameraMovementInputValue(map);
        }
        #endregion

    }
}
