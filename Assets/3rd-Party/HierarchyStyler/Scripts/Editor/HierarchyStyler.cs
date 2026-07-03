using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace HierarchyStylerLogic
{
    [InitializeOnLoad]
    public class HierarchyStyler
    {
        private static readonly Regex _pattern = new(@"^(-{3,})\s*(.+)$", RegexOptions.Compiled);
        
        private static readonly Dictionary<Color, GUIStyle> _styleCache = new();

        static HierarchyStyler()
        {
            EditorApplication.hierarchyWindowItemByEntityIdOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(EntityId instanceID, Rect rect)
        {
            if (EditorUtility.EntityIdToObject(instanceID) is not GameObject go)
            {
                return;
            }

            Match match = _pattern.Match(go.name);
            if (!match.Success)
            {
                return;
            }

            int dashCount = match.Groups[1].Value.Length;
            string title = match.Groups[2].Value;

            EditorGUI.DrawRect(rect, new Color(0.22f, 0.22f, 0.22f));

            EditorGUI.LabelField(rect, GUIContent.none);

            Color textColor = GetColorByDashCount(dashCount);

            if (!_styleCache.TryGetValue(textColor, out var style))
            {
                style = new GUIStyle(EditorStyles.boldLabel)
                {
                    alignment = TextAnchor.MiddleCenter,
                    normal = { textColor = textColor },
                    hover = { textColor = textColor },
                    active = { textColor = textColor },
                    focused = { textColor = textColor }
                };
                _styleCache[textColor] = style;
            }

            GUI.Label(rect, title, style);
        }

        private static Color GetColorByDashCount(int count)
        {
            return count switch
            {
                3 => new Color(0.118f, 0.471f, 0.596f),
                4 => new Color(0.561f, 0.820f, 0.620f),
                5 => new Color(1.0f, 0.55f, 0.0f),
                6 => new Color(0.6f, 1.0f, 0.4f),
                >= 7 => new Color(0.78f, 0.68f, 0.92f),
                _ => new Color(1f, 1f, 1f)
            };
        }
    }
}