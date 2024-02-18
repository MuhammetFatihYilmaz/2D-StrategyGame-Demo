using System;
using UnityEngine.AddressableAssets;

namespace StrategyGame.Management.ObjectPoolManagement
{
    public record ObjectPoolRegisterType
    {
        public readonly Type Type;
        public readonly AssetReference AssetReference;
        public ObjectPoolRegisterType(Type type, AssetReference assetReference)
        {
            Type = type;
            AssetReference = assetReference;
        }
    }
}
