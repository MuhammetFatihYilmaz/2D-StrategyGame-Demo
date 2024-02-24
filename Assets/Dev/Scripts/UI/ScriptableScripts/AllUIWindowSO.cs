using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.UI.ScriptableScripts.Window
{
    [CreateAssetMenu(fileName = nameof(AllUIWindowSO), menuName = "StrategyGame/UI/Window/" + nameof(AllUIWindowSO))]
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
