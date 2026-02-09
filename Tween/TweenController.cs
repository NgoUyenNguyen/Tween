using System.Collections.Generic;
using UnityEngine;

namespace NgoUyenNguyen
{
    public class TweenController : MonoBehaviour
    {
        [SerializeField] private List<Tween> tweens = new();
        
        public IEnumerable<Tween> Tweens => tweens;
        
        public int Count => tweens.Count;
        
        public void Add(Tween tween) => tweens.Add(tween);

        public bool Insert(int index, Tween tween)
        {
            if (index < 0 || index > tweens.Count) return false;
            
            tweens.Insert(index, tween);
            return true;
        }
        
        public bool Remove(Tween tween) => tweens.Remove(tween);

        public bool Remove(int index)
        {
            if (index < 0 || index >= tweens.Count) return false;
            
            tweens.RemoveAt(index);
            return true;
        }
        
        public void RemoveAll() => tweens.Clear();
        
        public Tween GetTween(string name) => tweens.Find(t => t.name == name);
        public Tween GetTween(int index) => index < tweens.Count && index >= 0 ? tweens[index] : null;

        public bool Play(string name)
        {
            var tween = GetTween(name);
            return tween != null && tween.Play(destroyCancellationToken);
        }
        
        public bool Play(int index)
        {
            var tween = GetTween(index);
            return tween != null && tween.Play(destroyCancellationToken);
        }

        public void Play(Tween tween) => tween?.Play(destroyCancellationToken);

        public void PlayAll()
        {
            foreach (var tween in tweens) tween?.Play(destroyCancellationToken);
        }

        public bool Pause(string tweenName)
        {
            var tween = GetTween(tweenName);
            return tween != null && tween.Pause();
        }
        
        public bool Pause(int index)
        {
            var tween = GetTween(index);
            return tween != null && tween.Pause();
        }
        
        public void PauseAll()
        {
            foreach (var tween in tweens) tween?.Pause();
        }

        public bool Resume(string tweenName)
        {
            var tween = GetTween(tweenName);
            return tween != null && tween.Resume();
        }
        
        public bool Resume(int index)
        {
            var tween = GetTween(index);
            return tween != null && tween.Resume();
        }

        public void ResumeAll()
        {
            foreach (var tween in tweens) tween?.Resume();
        }

        public bool Cancel(string tweenName)
        {
            var tween = GetTween(tweenName);
            return tween != null && tween.Cancel();
        }

        public bool Cancel(int index)
        {
            var tween = GetTween(index);
            return tween != null && tween.Cancel();
        }
        
        public void CancelAll()
        {
            foreach (var tween in tweens) tween?.Cancel();
        }
    }
}
