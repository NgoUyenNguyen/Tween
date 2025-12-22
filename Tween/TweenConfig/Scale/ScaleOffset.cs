using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale Offset")]
    public class ScaleOffset : TweenConfig
    {
        public Vector3 offset;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenTo = gameObjectToAnimate.transform.localScale + offset;
            return LeanTween.scale(gameObjectToAnimate, tweenTo, duration);
        }
    }

    [System.Serializable, AddTypeMenu("Scale/Scale Offset (Uniform)")]
    public class ScaleOffsetUniform : TweenConfig
    {
        public float offset;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenTo = gameObjectToAnimate.transform.localScale + Vector3.one * offset;
            return LeanTween.scale(gameObjectToAnimate, tweenTo, duration);
        }
    }
}