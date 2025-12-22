using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move Z")]
    public class MoveZ : TweenConfig
    {
        public float z;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.moveZ(gameObjectToAnimate, z, duration);
        }
    }
}