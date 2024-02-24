using System;
using UnityEngine.AddressableAssets;

namespace StrategyGame.Management.ObjectPoolManagement
{
    public record ObjectPoolRegisterType
    {
        public readonly Type Type;
        public readonly AssetReference AssetReference;
        public readonly string UID;
        public ObjectPoolRegisterType(Type type, AssetReference assetReference, string uid = "")
        {
            Type = type;
            AssetReference = assetReference;
            UID = uid;
        }
    }
}
