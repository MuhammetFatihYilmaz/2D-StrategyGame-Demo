using UnityEngine;

namespace StrategyGame.UI.Window.InGameplayWindow.Message
{
    [System.Serializable]
    public struct MessageMap
    {
        [field: SerializeField] public MessageType MessageType {get; private set;}
        [field: SerializeField] public string Message {get; private set; }
    }
}
