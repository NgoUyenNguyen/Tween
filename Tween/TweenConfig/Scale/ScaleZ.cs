using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale Z")]
    public class ScaleZ : TweenConfig
    {
        public float z;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.scaleZ(gameObjectToAnimate, z, duration);
        }
    }
}