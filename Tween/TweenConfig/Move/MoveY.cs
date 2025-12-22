using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move Y")]
    public class MoveY : TweenConfig
    {
        public float y;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.moveY(gameObjectToAnimate, y, duration);
        }
    }
}