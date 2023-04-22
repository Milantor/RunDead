using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ModificableFloat))]
public class ModificableFloatInspector : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.FindPropertyRelative("OriginalValue").floatValue = EditorGUI.FloatField(position, label, property.FindPropertyRelative("OriginalValue").floatValue);
    }
}