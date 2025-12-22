using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move From To")]
    public class MoveFromTo : TweenConfig
    {
        public Space space = Space.Self;
        public Vector3 from;
        public Vector3 to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenFrom = from;
            var tweenTo = to;
            if (space == Space.Self && gameObjectToAnimate.transform.parent != null)
            {
                tweenFrom = gameObjectToAnimate.transform.parent.TransformPoint(from);
                tweenTo = gameObjectToAnimate.transform.parent.TransformPoint(to);
            }

            return LeanTween.move(gameObjectToAnimate, tweenTo, duration).setFrom(tweenFrom);
        }
    }
    
    [System.Serializable, AddTypeMenu("Move/Move From To (Transform)")]
    public class MoveFromToTransform : TweenConfig
    {
        public Transform from;
        public Transform to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            if (from == null || to == null) return null;
            return LeanTween.move(gameObjectToAnimate, to, duration).setFrom(from.position);
        }
    }
}