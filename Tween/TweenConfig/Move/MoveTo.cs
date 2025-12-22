using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Move/Move To")]
    public class MoveTo : TweenConfig
    {
        public Space space = Space.Self;
        public Vector3 to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            var tweenTo = to;
            if (space == Space.Self && gameObjectToAnimate.transform.parent != null)
            {
                tweenTo = gameObjectToAnimate.transform.parent.TransformPoint(to);
            }
            
            return LeanTween.move(gameObjectToAnimate, tweenTo, duration);
        }
    }
    
    [System.Serializable, AddTypeMenu("Move/Move To (Transform)")]
    public class MoveToTransform : TweenConfig
    {
        public Transform to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return to == null ? null : LeanTween.move(gameObjectToAnimate, to, duration);
        }
    }
}