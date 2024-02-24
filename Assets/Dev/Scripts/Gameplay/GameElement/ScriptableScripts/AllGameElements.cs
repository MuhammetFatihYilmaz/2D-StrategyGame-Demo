using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.GameElement
{
    [CreateAssetMenu(fileName = nameof(AllGameElements), menuName = "StrategyGame/Gameplay/GameElement/" + nameof(AllGameElements))]
    public class AllGameElements : PoolPrefabSO
    {
        [SerializeField] private List<GameElementSO> AllGameElementSOList;
        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var element in AllGameElementSOList)
            {
                yield return new ObjectPoolRegisterType(element.AssetReferenceType.MonoReference.GetType(),
                                                        element.AssetReferenceType.AssetReference);
            }
        }
    }
}
