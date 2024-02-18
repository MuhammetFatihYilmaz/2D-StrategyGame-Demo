using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.UI.ScriptableScripts
{
    [CreateAssetMenu(fileName = nameof(AllUIWindowSO), menuName = "StrategyGame/UI/" + nameof(AllUIWindowSO))]
    public class AllUIWindowSO : PoolPrefabSO
    {
        [field: SerializeField] public List<UIWindowSO> AllUIWindowSOList { get; private set; }

        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var uiWindow in AllUIWindowSOList)
            {
                yield return new ObjectPoolRegisterType(uiWindow.AssetReferenceType.MonoReference.GetType(), uiWindow.AssetReferenceType.AssetReference);
            }
        }
    }
}
