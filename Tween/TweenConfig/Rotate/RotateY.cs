using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate Y")]
    public class RotateY : TweenConfig
    {
        public float y;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.rotateY(gameObjectToAnimate, y, duration);
        }
    }
}