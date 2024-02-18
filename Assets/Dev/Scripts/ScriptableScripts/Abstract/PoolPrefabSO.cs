using StrategyGame.Management.ObjectPoolManagement;
using System.Collections.Generic;

namespace StrategyGame.ScriptableScripts
{
    public abstract class PoolPrefabSO : GameBaseSO
    {
        public abstract IEnumerable<ObjectPoolRegisterType> RegisterPrefabType();
    }
}
