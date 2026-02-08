using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace NgoUyenNguyen
{
    [CustomEditor(typeof(TweenController))]
    public class TweenControllerEditor : UnityEditor.Editor
    {
        [SerializeField] private VisualTreeAsset visualTreeAsset;
        
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement(); 
            visualTreeAsset.CloneTree(root);
            return root;
        }
    }
}
