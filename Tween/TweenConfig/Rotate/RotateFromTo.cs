using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate From To")]
    public class RotateFromTo : TweenConfig
    {
        public Space space = Space.Self;
        public Vector3 from;
        public Vector3 to;

        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenFrom = Quaternion.Euler(from);
            var tweenTo = Quaternion.Euler(to);

            if (space == Space.World && gameObjectToAnimate.transform.parent != null)
            {
                var parentRotation = gameObjectToAnimate.transform.parent.rotation;
                tweenFrom = Quaternion.Inverse(parentRotation) * tweenFrom;
                tweenTo = Quaternion.Inverse(parentRotation) * tweenTo;
            }

            return LeanTween.value(gameObjectToAnimate, 0f, 1f, duration)
                .setOnUpdate(t =>
                {
                    var q = Quaternion.Slerp(tweenFrom, tweenTo, t);
                    gameObjectToAnimate.transform.localRotation = q;
                });
        }
    }
}