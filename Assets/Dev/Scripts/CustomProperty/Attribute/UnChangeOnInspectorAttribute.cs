#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace StrategyGame.CustomProperty.Attribute
{
    public class UnChangeOnInspectorAttribute : PropertyAttribute
    {

    }


    [CustomPropertyDrawer(typeof(UnChangeOnInspectorAttribute))]
    public class UnChangeOnInspectorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position,
                                   SerializedProperty property,
                                   GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
#endif
