using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move X")]
    public class MoveX : TweenConfig
    {
        public float x;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.moveX(gameObjectToAnimate, x, duration);
        }
    }
}