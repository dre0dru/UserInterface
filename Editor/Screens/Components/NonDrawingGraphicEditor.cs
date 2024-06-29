using Dre0Dru.Screens.UGUI.Components;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

namespace Dre0Dru.Screens.Editor.Components
{
    [CanEditMultipleObjects, CustomEditor(typeof(NonDrawingGraphic), false)]
    public class NonDrawingGraphicEditor : GraphicEditor
    {
        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Script, new GUILayoutOption[0]);
            // skipping AppearanceControlsGUI
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
