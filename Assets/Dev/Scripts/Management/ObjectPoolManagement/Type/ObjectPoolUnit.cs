using System.Collections.Generic;
using System.Linq;

namespace StrategyGame.Management.ObjectPoolManagement
{
    public class ObjectPoolUnit
    {
        public readonly ObjectPoolRegisterType ObjectUnitType;
        private List<IObjectPoolItem> pooledPrefabList;
        public ObjectPoolUnit(ObjectPoolRegisterType objectUnitType)
        {
            ObjectUnitType = objectUnitType;
            pooledPrefabList ??= new();
        }

        public void AddPrefabToPool(IObjectPoolItem prefab)
        {
            pooledPrefabList.Add(prefab);
        }

        public IObjectPoolItem PullPrefabToPool()
        {
            var prefab = pooledPrefabList.FirstOrDefault();
            pooledPrefabList.Remove(pooledPrefabList.FirstOrDefault());
            return prefab;
        }

        public bool IsHaveAnyPooledPrefab()
        {
            return pooledPrefabList.Any();
        }
    }
}
