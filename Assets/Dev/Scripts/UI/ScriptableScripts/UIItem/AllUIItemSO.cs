using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.UI.ScriptableScripts.UIItem
{
    [CreateAssetMenu(fileName = nameof(AllUIItemSO), menuName = "StrategyGame/UI/UIItem/" + nameof(AllUIItemSO))]
    public class AllUIItemSO : PoolPrefabSO
    {
        [field: SerializeField] public List<UIItemSO> AllUIItemSOList { get; private set; }

        public override IEnumerable<ObjectPoolRegisterType> RegisterPrefabType()
        {
            foreach (var uiItem in AllUIItemSOList)
            {
                yield return new ObjectPoolRegisterType(uiItem.AssetReferenceType.MonoReference.GetType(), uiItem.AssetReferenceType.AssetReference);
            }
        }
    }
}
