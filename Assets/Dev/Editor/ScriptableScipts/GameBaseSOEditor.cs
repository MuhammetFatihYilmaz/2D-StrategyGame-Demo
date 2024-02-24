#if UNITY_EDITOR
using StrategyGame.ScriptableScripts;
using UnityEditor;
using UnityEngine;

namespace StrategyGame.Editor.ScriptableScripts
{
    [CustomEditor(typeof(GameBaseSO), true)]
    public class GameBaseSOEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameBaseSO gameBaseSO = (GameBaseSO)target;
            if (GUILayout.Button("Reset UID"))
                gameBaseSO.ResetUID();
        }
    }
}
#endif
