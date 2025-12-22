using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale To")]
    public class ScaleTo : TweenConfig
    {
        public Vector3 to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.scale(gameObjectToAnimate, to, duration);
        }
    }

    [System.Serializable, AddTypeMenu("Scale/Scale To (Uniform)")]
    public class ScaleToUniform : TweenConfig
    {
        public float to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.scale(gameObjectToAnimate, Vector3.one * to, duration);
        }
    }
}