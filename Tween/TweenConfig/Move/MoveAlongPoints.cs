using System;
using UnityEngine;

namespace NgoUyenNguyen
{
    [Serializable, AddTypeMenu("Move/Move Along Points")]
    public class MoveAlongPoints : TweenConfig
    {
        public Vector3[] points = Array.Empty<Vector3>();
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return LeanTween.move(gameObjectToAnimate, points, duration);
        }
    }
}