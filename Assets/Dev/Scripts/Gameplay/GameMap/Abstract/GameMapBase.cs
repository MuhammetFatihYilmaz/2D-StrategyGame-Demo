using StrategyGame.Gameplay.PathFinding;
using StrategyGame.Gameplay.Placement;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace StrategyGame.Gameplay.GameMap
{
    public abstract class GameMapBase : MonoBehaviour, IObjectPoolItem
    {
        [field: SerializeField] public PlacementController PlacementController { get; private set; }
        [field: SerializeField] public Grid2D Grid { get; private set; }
        [field: SerializeField] public Tilemap ObstacleTilemap { get; private set; }
        [field: SerializeField] public Tile ReplaceObstacleTile{ get; private set; }
    }
}
