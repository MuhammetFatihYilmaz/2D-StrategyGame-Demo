using StrategyGame.ScriptableScripts;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.UI.Window.InGameplayWindow.Message
{
    [CreateAssetMenu(fileName = nameof(AllMessageSO), menuName = "StrategyGame/UI/Window/InGameplayWindow/Message/" + nameof(AllMessageSO))]
    public class AllMessageSO : GameBaseSO
    {
        [field: SerializeField] public List<MessageSO> AllMessageSOList { get; private set; }
    }
}
