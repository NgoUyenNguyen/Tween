using UnityEngine;
using UnityEngine.UI;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Blend/Blend Color From To")]
    public class BlendColorFromTo : TweenConfig
    {
        public BlendColorTarget target = BlendColorTarget.None;
        public Color from = Color.white;
        public Color to = Color.white;

        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return target switch
            {
                BlendColorTarget.Image when gameObjectToAnimate.TryGetComponent(out Image image) => LeanTween
                    .value(gameObjectToAnimate, 0, 1, duration)
                    .setOnUpdate(t => { image.color = Color.Lerp(from, to, t); }),
                BlendColorTarget.SpriteRenderer when
                    gameObjectToAnimate.TryGetComponent(out SpriteRenderer spriteRenderer) => LeanTween
                        .value(gameObjectToAnimate, 0, 1, duration)
                        .setOnUpdate(t => { spriteRenderer.color = Color.Lerp(from, to, t); }),
                _ => null
            };
        }
    }
}