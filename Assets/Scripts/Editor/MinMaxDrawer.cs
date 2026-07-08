#if UNITY_EDITOR

using StalkerSimulation.Attributes;
using UnityEditor;
using UnityEngine;

namespace StalkerSimulation.Editor
{
	[CustomPropertyDrawer(typeof(MinMaxAttribute))]
	public class MinMaxDrawer : PropertyDrawer
    {
        private const float FieldWidth = 55f;
        private const float Spacing = 4f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Generic)
            {
                EditorGUI.LabelField(position, label.text, "Use MinMax only with FloatRange.");
                return;
            }

            SerializedProperty minProperty = property.FindPropertyRelative("<Min>k__BackingField");
            SerializedProperty maxProperty = property.FindPropertyRelative("<Max>k__BackingField");

            MinMaxAttribute attributeData = (MinMaxAttribute)attribute;

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, label);

            Rect minFieldRect = new Rect(
                position.x,
                position.y,
                FieldWidth,
                position.height);

            Rect maxFieldRect = new Rect(
                position.xMax - FieldWidth,
                position.y,
                FieldWidth,
                position.height);

            Rect sliderRect = new Rect(
                minFieldRect.xMax + Spacing,
                position.y,
                position.width - FieldWidth * 2 - Spacing * 2,
                position.height);

            float min = minProperty.floatValue;
            float max = maxProperty.floatValue;

            EditorGUI.BeginChangeCheck();

            min = EditorGUI.FloatField(minFieldRect, min);

            EditorGUI.MinMaxSlider(
                sliderRect,
                ref min,
                ref max,
                attributeData.Min,
                attributeData.Max);

            max = EditorGUI.FloatField(maxFieldRect, max);

            if (EditorGUI.EndChangeCheck())
            {
                min = Mathf.Clamp(min, attributeData.Min, attributeData.Max);
                max = Mathf.Clamp(max, attributeData.Min, attributeData.Max);

                if (min > max)
                {
                    if (GUI.GetNameOfFocusedControl() == "")
                    {
                        min = max;
                    }
                    else
                    {
                        max = min;
                    }
                }

                minProperty.floatValue = min;
                maxProperty.floatValue = max;
            }

            EditorGUI.EndProperty();
        }
    }
}

#endif