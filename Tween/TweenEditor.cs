using UnityEditor;
using UnityEngine;

namespace NgoUyenNguyen
{
    [CustomEditor(typeof(Tween))]
    public class TweenEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        
            EditorGUILayout.Space();
            if (GUILayout.Button("Play"))
            {
                ((Tween)target).Play();
            }
            if (GUILayout.Button("Pause"))
            {
                ((Tween)target).Pause();
            }
        
            if (GUILayout.Button("Resume"))
            {
                ((Tween)target).Resume();
            }
            if (GUILayout.Button("Cancel"))
            {
                ((Tween)target).Cancel();
            }
        }
    }
}
