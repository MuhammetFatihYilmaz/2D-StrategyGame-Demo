using StrategyGame.Gameplay.Placement;
using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.Gameplay.GameMap
{
    public abstract class GameMapBase : MonoBehaviour, IObjectPoolItem
    {
        [field: SerializeField] public PlacementController PlacementController { get; set; }

    }
}
