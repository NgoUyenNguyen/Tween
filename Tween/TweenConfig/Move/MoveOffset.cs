using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move Offset")]
    public class MoveOffset : TweenConfig
    {
        public Vector3 offset;

        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenTo = gameObjectToAnimate.transform.position + offset;
            return LeanTween.move(gameObjectToAnimate, tweenTo, duration);
        }
    }
}