using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Rotate/Rotate To")]
    public class RotateTo : TweenConfig
    {
        public Space space = Space.Self;
        public Vector3 to;

        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenFrom = gameObjectToAnimate.transform.rotation;
            var tweenTo = Quaternion.Euler(to);
            
            if (space == Space.World && gameObjectToAnimate.transform.parent != null)
            {
                var parentRotation = gameObjectToAnimate.transform.parent.rotation;
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