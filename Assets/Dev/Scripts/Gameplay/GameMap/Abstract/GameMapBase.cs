using StrategyGame.Gameplay.PathFinding;
using StrategyGame.Gameplay.Placement;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.GameMap
{
    public abstract class GameMapBase : MonoBehaviour, IObjectPoolItem
    {
        [field: SerializeField] public PlacementController PlacementController { get; private set; }
        [field: SerializeField] public Grid2D Grid { get; private set; }
    }
}
