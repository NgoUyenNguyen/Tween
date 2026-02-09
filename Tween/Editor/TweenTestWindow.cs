using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace NgoUyenNguyen
{
    public class TweenTestWindow : PopupWindowContent
    {
        private readonly TweenController tweenController;
        private readonly VisualTreeAsset visualTreeAsset;
        
        public TweenTestWindow(TweenController tweenController, 
            VisualTreeAsset visualTreeAsset)
        {
            this.tweenController = tweenController;
            this.visualTreeAsset = visualTreeAsset;
        }
        
        public override Vector2 GetWindowSize() => new (300, 600);

        public override VisualElement CreateGUI()
        {
            var root = new VisualElement();
            visualTreeAsset.CloneTree(root);
            
            var listView = root.Q<ListView>();
            listView.itemsSource = tweenController.Tweens.ToList();
            listView.bindItem = (element, id) =>
            {
                element.Q<Label>().text = $"{id}. {tweenController.GetTween(id).name}";
                
                var playButton = element.Q<Button>(name: "play");
                playButton.clicked += () => tweenController.Play(id);

                var pauseButton = element.Q<Button>(name: "pause");
                pauseButton.clicked += () => tweenController.Pause(id);

                var resumeButton = element.Q<Button>(name: "resume");
                resumeButton.clicked += () => tweenController.Resume(id);

                var cancelButton = element.Q<Button>(name: "cancel");
                cancelButton.clicked += () => tweenController.Cancel(id);
            };
            
            return root;    
        }
    }
}