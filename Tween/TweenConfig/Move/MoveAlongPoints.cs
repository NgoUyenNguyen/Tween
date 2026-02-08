using System;
using System.Linq;
using UnityEngine;

namespace NgoUyenNguyen
{
    [Serializable, AddTypeMenu("Move/Move Along Points")]
    public class MoveAlongPoints : TweenConfig
    {
        public Vector3[] points = Array.Empty<Vector3>();
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate) => 
            LeanTween.move(gameObjectToAnimate, points, duration);
    }
    
    [Serializable, AddTypeMenu("Move/Move Along Points (Transform)")]
    public class MoveAlongTransforms : TweenConfig
    {
        public Transform[] points = Array.Empty<Transform>();
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate) => 
            LeanTween.move(gameObjectToAnimate, points.Select(p => p.position).ToArray(), duration);
    }
}