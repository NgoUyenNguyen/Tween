using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using PopupWindow = UnityEditor.PopupWindow;

namespace NgoUyenNguyen
{
    [CustomEditor(typeof(TweenController))]
    public class TweenControllerEditor : UnityEditor.Editor
    {
        [SerializeField] private VisualTreeAsset visualTreeAsset;
        [SerializeField] private VisualTreeAsset testWindowTreeAsset;
        
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement(); 
            visualTreeAsset.CloneTree(root);
            
            var testButton = root.Q<Button>(name:"test");
            testButton.style.display = EditorApplication.isPlaying
                ? DisplayStyle.Flex 
                : DisplayStyle.None;
            testButton.clicked += () =>
                PopupWindow.Show(testButton.worldBound, new TweenTestWindow(target as TweenController, 
                    testWindowTreeAsset));
            
            return root;
        }
    }
}
