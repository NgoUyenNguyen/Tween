using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate Offset")]
    public class RotateOffset : TweenConfig
    {
        public Vector3 offset;

        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenFrom = gameObjectToAnimate.transform.rotation;
            var tweenTo = Quaternion.Euler(offset) * gameObjectToAnimate.transform.localRotation;
            
            return LeanTween.value(gameObjectToAnimate, 0f, 1f, duration)
                .setOnUpdate(t =>
                {
                    var q = Quaternion.Slerp(tweenFrom, tweenTo, t);
                    gameObjectToAnimate.transform.localRotation = q;
                });
        }
    }
}