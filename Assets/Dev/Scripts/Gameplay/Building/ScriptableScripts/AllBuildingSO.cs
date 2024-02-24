using StrategyGame.Gameplay.Building;
using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Gameplay.Building
{
    [CreateAssetMenu(fileName = nameof(AllBuildingSO), menuName = "StrategyGame/Gameplay/Building/" + nameof(AllBuildingSO))]

    public class AllBuildingSO : PoolPrefabSO
    {
        [field: SerializeField] public List<BuildingSO> AllBuildingSOList { get; private set; }

        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var building in AllBuildingSOList)
            {
                yield return new ObjectPoolRegisterType(typeof(BuildingBase),
                                                        building.AssetReferenceType.AssetReference,
                                                        building.UID);
            }
        }
    }
}
