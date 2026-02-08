using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace NgoUyenNguyen
{
    [CustomPropertyDrawer(typeof(Tween))]
    public class TweenPropertyDrawer : PropertyDrawer
    {
        [SerializeField] private VisualTreeAsset visualTreeAsset;
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();
            visualTreeAsset.CloneTree(root);

            if (!EditorApplication.isPlaying)
            {
                root.Q<Tab>(name:"test").RemoveFromHierarchy();
            }            
            
            return root;
        }
    }
}