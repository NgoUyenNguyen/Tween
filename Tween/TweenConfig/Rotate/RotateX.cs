using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate X")]
    public class RotateX : TweenConfig
    {
        public float x;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.rotateX(gameObjectToAnimate, x, duration);
        }
    }
}