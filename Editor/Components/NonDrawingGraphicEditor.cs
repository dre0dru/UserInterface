using System;
using Dre0Dru.Screens.UGUI.Components;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Dre0Dru.UI.Components.Editor
{
    [CanEditMultipleObjects, CustomEditor(typeof(NonDrawingGraphic), false)]
    public class NonDrawingGraphicEditor : GraphicEditor
    {
        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Script, Array.Empty<GUILayoutOption>());
            // skipping AppearanceControlsGUI
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
