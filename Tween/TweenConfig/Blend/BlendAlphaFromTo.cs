using UnityEngine;
using UnityEngine.UI;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Blend/Blend Alpha From To")]
    public class BlendAlphaFromTo : TweenConfig
    {
        public BlendAlphaTarget target = BlendAlphaTarget.None;
        [Range(0,1)] public float from;
        [Range(0,1)] public float to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            return target switch
            {
                BlendAlphaTarget.CanvasGroup when gameObjectToAnimate.TryGetComponent<CanvasGroup>(out var canvasGroup) =>
                    LeanTween.value(gameObjectToAnimate, from, to, duration)
                        .setOnUpdate(t => { canvasGroup.alpha = t; }),
                BlendAlphaTarget.Image when gameObjectToAnimate.TryGetComponent<Image>(out var image) => LeanTween
                    .value(gameObjectToAnimate, from, to, duration)
                    .setOnUpdate(t =>
                    {
                        var color = image.color;
                        color.a = t;
                        image.color = color;
                    }),
                BlendAlphaTarget.SpriteRenderer when
                    gameObjectToAnimate.TryGetComponent<SpriteRenderer>(out var spriteRenderer) => LeanTween
                        .value(gameObjectToAnimate, from, to, duration)
                        .setOnUpdate(t =>
                        {
                            var color = spriteRenderer.color;
                            color.a = t;
                            spriteRenderer.color = color;
                        }),
                _ => null
            };
        }
    }
}