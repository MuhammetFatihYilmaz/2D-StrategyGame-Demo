using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StrategyGame.ScriptableScripts
{
    [Serializable]
    public struct AssetReferenceType
    {
        [HideInInspector] public int selectedMonoBehaviorIndex;
        public MonoBehaviour MonoReference;
        public AssetReference AssetReference;
    }
}
