using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    [CreateAssetMenu(fileName = nameof(AllProduceUnitSO), menuName = "StrategyGame/Gameplay/Building/ProduceUnit/" + nameof(AllProduceUnitSO))]
    public class AllProduceUnitSO : PoolPrefabSO
    {
        [field: SerializeField] public List<ProduceUnitSO> AllProduceUnitSOList { get; private set; }

        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var produceUnit in AllProduceUnitSOList)
            {
                yield return new ObjectPoolRegisterType(typeof(ProduceUnitBase),
                                                        produceUnit.AssetReferenceType.AssetReference,
                                                        produceUnit.UID);
            }
        }
    }
}
