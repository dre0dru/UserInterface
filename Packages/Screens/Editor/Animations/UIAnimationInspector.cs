using Screens.Animations;
using UnityEditor;
using UnityEngine;

namespace Screens.Editor.Animations
{
    [CustomEditor(typeof(UIAnimation), true)]
    public class UIAnimationInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Play"))
            {
               var animation = (UIAnimation)target;
               animation.Play();
            }
            
            if (GUILayout.Button("Stop (complete)"))
            {
                var animation = (UIAnimation)target;
                animation.Stop(true);
            }
            
            if (GUILayout.Button("Stop (don't complete)"))
            {
                var animation = (UIAnimation)target;
                animation.Stop(false);
            }
        }
    }
}
