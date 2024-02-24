#if UNITY_EDITOR
using StrategyGame.CustomProperty.Attribute;
#endif
using UnityEditor;
using UnityEngine;

namespace StrategyGame.ScriptableScripts
{
    public abstract class GameBaseSO : ScriptableObject
    {
#if UNITY_EDITOR
        [UnChangeOnInspector]
#endif
        [SerializeField] private string uid;
        public string UID
        {
            get => uid; 
            private set => uid = value;
        }


#if UNITY_EDITOR
        public void ResetUID()
        {
            UID = GUID.Generate().ToString();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}
