using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = nameof(AllEnemySO), menuName = "StrategyGame/Gameplay/Enemy/" + nameof(AllEnemySO))]
    public class AllEnemySO : PoolPrefabSO
    {
        [field: SerializeField] public List<EnemySO> AllEnemySOList { get; private set; }

        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var enemy in AllEnemySOList)
            {
                yield return new ObjectPoolRegisterType(enemy.AssetReferenceType.MonoReference.GetType(),
                                                        enemy.AssetReferenceType.AssetReference,
                                                        enemy.UID);
            }
        }
    }
}
