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
        [Min(0)] public float delay;
        public LoopType loopType = LoopType.None;
        public LeanTweenType easeType = LeanTweenType.notUsed;
        public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 0);
        public UnityEngine.Events.UnityEvent onStart;
        public UnityEngine.Events.UnityEvent onComplete;

        public int? Play(GameObject gameObjectToAnimate)
        {
            if (!enable) return null;
            
            var tween = RunTween(gameObjectToAnimate);
            if (tween == null) return null;

            tween.setOnStart(() => onStart?.Invoke())
                .setOnComplete(() => onComplete?.Invoke())
                .setDelay(delay);
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
            
            return tween.uniqueId;
        }

        protected abstract LTDescr RunTween(GameObject gameObjectToAnimate);
    }
}