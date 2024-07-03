using Dre0Dru.UI.Screens.UGUI.Components;
using UnityEditor;
using UnityEditor.UI;

namespace Dre0Dru.UI.Screens.Editor.Components
{
    [CanEditMultipleObjects, CustomEditor(typeof(MisstapCatcher<>), true)]
    public class MisstapCatcherEditor : ButtonEditor
    {
        private SerializedProperty _screenProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            _screenProperty = serializedObject.FindProperty("_screen");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            serializedObject.Update();
            EditorGUILayout.PropertyField(_screenProperty);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
