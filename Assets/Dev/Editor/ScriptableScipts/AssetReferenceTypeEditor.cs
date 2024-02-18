#if UNITY_EDITOR

using StrategyGame.ScriptableScripts;
using UnityEditor;
using UnityEngine;

namespace StrategyGame.Editor.ScriptableScripts
{
    [CustomEditor(typeof(AssetReferenceBaseSO), true)]

    public class AssetReferenceTypeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AssetReferenceBaseSO assetReferenceSO = (AssetReferenceBaseSO)target;
            GUILayout.Space(10);
            EditorGUILayout.LabelField("Select a MonoBehavior Script:");

            if (!assetReferenceSO.AssetReferenceType.MonoReference) return;
            MonoBehaviour[] monoBehaviors = assetReferenceSO.AssetReferenceType.MonoReference.GetComponents<MonoBehaviour>();

            string[] monoBehaviorNames = new string[monoBehaviors.Length];
            for (int i = 0; i < monoBehaviors.Length; i++)
            {
                monoBehaviorNames[i] = monoBehaviors[i].GetType().ToString();
            }

            int selectedMonoBehaviorIndex = EditorGUILayout.Popup("Select MonoBehavior", assetReferenceSO.AssetReferenceType.selectedMonoBehaviorIndex, monoBehaviorNames);

            if (selectedMonoBehaviorIndex >= 0 && selectedMonoBehaviorIndex < monoBehaviors.Length)
            {
                assetReferenceSO.AssetReferenceType.selectedMonoBehaviorIndex = selectedMonoBehaviorIndex;
                assetReferenceSO.AssetReferenceType.MonoReference = monoBehaviors[selectedMonoBehaviorIndex];
            }
        }
    }
}
#endif