using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable]
    public abstract class TweenConfig
    {
        public enum LoopType
        {
            None,
            Repeat,
            PingPong
        }

        public bool enable = true;
        public float duration = 1f;
        public float delay = 0f;
        public LoopType loopType = LoopType.None;
        public LeanTweenType easeType = LeanTweenType.notUsed;
        public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 0);
        public UnityEngine.Events.UnityEvent onStart;
        public UnityEngine.Events.UnityEvent onComplete;

        public void Play(GameObject gameObjectToAnimate)
        {
            if (!enable) return;
            
            var tween = RunTween(gameObjectToAnimate);
            if (tween == null) return;
            
            tween.setDelay(delay)
                .setOnStart(() => onStart.Invoke())
                .setOnComplete(() => onComplete.Invoke());
            if (easeType == LeanTweenType.animationCurve) tween.setEase(animationCurve);
            else tween.setEase(easeType);

            switch (loopType)
            {
                case LoopType.Repeat:
                    tween.setLoopCount(-1);
                    break;
                case LoopType.PingPong:
                    tween.setLoopPingPong();
                    break;
            }
        }

        public void Cancel(GameObject gameObjectToAnimate) => LeanTween.cancel(gameObjectToAnimate);

        public void Pause(GameObject gameObjectToAnimate) => LeanTween.pause(gameObjectToAnimate);

        public void Resume(GameObject gameObjectToAnimate)
        {
            if (!enable) return;
            LeanTween.resume(gameObjectToAnimate);
        }

        protected abstract LTDescr RunTween(GameObject gameObjectToAnimate);
    }
}