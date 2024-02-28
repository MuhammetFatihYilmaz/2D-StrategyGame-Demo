using StrategyGame.ScriptableScripts;
using UnityEngine;

namespace StrategyGame.UI.Window.InGameplayWindow.Message
{
    [CreateAssetMenu(fileName = nameof(MessageSO), menuName = "StrategyGame/UI/Window/InGameplayWindow/Message/" + nameof(MessageSO))]
    public class MessageSO : GameBaseSO
    {
        [field: SerializeField] public MessageMap MessageMap { get; private set; }
    }
}
