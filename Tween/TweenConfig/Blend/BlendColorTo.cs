using UnityEngine;
using UnityEngine.UI;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Blend/Blend Color To")]
    public class BlendColorTo : TweenConfig
    {
        public BlendColorTarget target = BlendColorTarget.None;
        public Color to = Color.white;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return target switch
            {
                BlendColorTarget.Image when gameObjectToAnimate.TryGetComponent(out Image image) => LeanTween
                    .value(gameObjectToAnimate, image.color, to, duration)
                    .setOnUpdate(t => { image.color = t; }),
                BlendColorTarget.SpriteRenderer when
                    gameObjectToAnimate.TryGetComponent(out SpriteRenderer spriteRenderer) => LeanTween
                        .value(gameObjectToAnimate, spriteRenderer.color, to, duration)
                        .setOnUpdate(t => { spriteRenderer.color = t; }),
                _ => null
            };
        }
    }
}