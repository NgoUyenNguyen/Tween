using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NgoUyenNguyen
{
    public class Tween : MonoBehaviour
    {
        public GameObject gameObjectToAnimate;

        [SerializeReference, SubclassSelector] public List<TweenConfig> tweenConfigs;
        
        public UnityEvent onStart;
        public UnityEvent onComplete;
        
        private bool isPausing;
        
        [ContextMenu("Play")]
        public void Play()
        {
            if (!Application.isPlaying) return;
            
            onStart?.Invoke();
            StopAllCoroutines();
            
            if (gameObjectToAnimate == null) return;
            foreach (var tweenConfig in tweenConfigs)
                tweenConfig?.Play(gameObjectToAnimate);
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            while (LeanTween.isTweening(gameObjectToAnimate)) yield return null;
            onComplete?.Invoke();
        }
        
        [ContextMenu("Cancel")]
        public void Cancel()
        {
            if (gameObjectToAnimate == null) return;
            foreach (var tweenConfig in tweenConfigs)
                tweenConfig?.Cancel(gameObjectToAnimate);
        }
        
        [ContextMenu("Pause")]
        public void Pause()
        {
            if (gameObjectToAnimate == null) return;
            foreach (var tweenConfig in tweenConfigs)
                tweenConfig?.Pause(gameObjectToAnimate);
        }
        
        [ContextMenu("Resume")]
        public void Resume()
        {
            if (gameObjectToAnimate == null) return;
            foreach (var tweenConfig in tweenConfigs)
                tweenConfig?.Resume(gameObjectToAnimate);
        }
    }
}