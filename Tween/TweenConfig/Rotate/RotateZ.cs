using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate Z")]
    public class RotateZ : TweenConfig
    {
        public float z;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.rotateZ(gameObjectToAnimate, z, duration);
        }
    }
}