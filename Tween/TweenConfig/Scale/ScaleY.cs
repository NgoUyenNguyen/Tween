using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale Y")]
    public class ScaleY : TweenConfig
    {
        public float y;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.scaleY(gameObjectToAnimate, y, duration);
        }
    }
}