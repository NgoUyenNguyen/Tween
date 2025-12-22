using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale X")]
    public class ScaleX : TweenConfig
    {
        public float x;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.scaleX(gameObjectToAnimate, x, duration);
        }
    }
}