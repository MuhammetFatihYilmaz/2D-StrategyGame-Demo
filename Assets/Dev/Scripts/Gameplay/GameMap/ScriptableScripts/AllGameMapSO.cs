using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.GameMap
{
    [CreateAssetMenu(fileName = nameof(AllGameMapSO), menuName = "StrategyGame/Gameplay/GameMap/" + nameof(AllGameMapSO))]
    public class AllGameMapSO : PoolPrefabSO
    {
        [field: SerializeField] public List<GameMapSO> GameMapSOList { get; private set; }
        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var map in GameMapSOList)
            {
                yield return new ObjectPoolRegisterType(typeof(GameMapBase),
                                                        map.AssetReferenceType.AssetReference,
                                                        map.UID);
            }
        }
    }
}
