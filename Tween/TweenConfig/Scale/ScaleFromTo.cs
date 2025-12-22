using UnityEngine;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Scale/Scale From To")]
    public class ScaleFromTo : TweenConfig
    {
        public Space space = Space.Self;
        public Vector3 from;
        public Vector3 to;

        protected override LTDescr RunTween(GameObject go)
        {
            if (space == Space.Self)
            {
                return LeanTween.scale(go, to, duration)
                    .setFrom(from);
            }

            return LeanTween.value(go, 0f, 1f, duration)
                .setOnUpdate(t =>
                {
                    var worldScale = Vector3.LerpUnclamped(from, to, t);
                    go.transform.localScale =
                        WorldToLocalScale(go.transform, worldScale);
                });
        }
        
        public static Vector3 WorldToLocalScale(Transform transform, Vector3 worldScale)
        {
            if (transform.parent == null)
                return worldScale;

            var p = transform.parent.lossyScale;

            return new Vector3(
                p.x != 0 ? worldScale.x / p.x : worldScale.x,
                p.y != 0 ? worldScale.y / p.y : worldScale.y,
                p.z != 0 ? worldScale.z / p.z : worldScale.z
            );
        }
    }


    [System.Serializable, AddTypeMenu("Scale/Scale From To (Uniform)")]
    public class ScaleFromToUniform : TweenConfig
    {
        public Space space = Space.Self;
        public float from;
        public float to;

        protected override LTDescr RunTween(GameObject go)
        {
            if (space == Space.Self)
            {
                return LeanTween.scale(go, Vector3.one * to, duration)
                    .setFrom(Vector3.one * from);
            }

            return LeanTween.value(go, 0f, 1f, duration)
                .setOnUpdate(t =>
                {
                    float world = Mathf.LerpUnclamped(from, to, t);
                    var worldScale = Vector3.one * world;

                    go.transform.localScale =
                        ScaleFromTo.WorldToLocalScale(go.transform, worldScale);
                });
        }
    }
}