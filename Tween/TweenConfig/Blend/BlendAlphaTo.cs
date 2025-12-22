using UnityEngine;
using UnityEngine.UI;

namespace NgoUyenNguyen
{
    [System.Serializable, AddTypeMenu("Blend/Blend Alpha To")]
    public class BlendAlphaTo : TweenConfig
    {
        public BlendAlphaTarget target = BlendAlphaTarget.None;
        [Range(0,1)] public float to;
        
        protected override LTDescr RunTween(GameObject gameObjectToAnimate)
        {
            switch (target)
            {
                case BlendAlphaTarget.CanvasGroup when
                    gameObjectToAnimate.TryGetComponent<CanvasGroup>(out var canvasGroup):
                {
                    var from = canvasGroup.alpha;
                    return LeanTween.value(gameObjectToAnimate, from, to, duration)
                        .setOnUpdate(t =>
                        {
                            canvasGroup.alpha = t;
                        });
                }
                case BlendAlphaTarget.Image when gameObjectToAnimate.TryGetComponent<Image>(out var image):
                {
                    var from = image.color.a;
                    return LeanTween.value(gameObjectToAnimate, from, to, duration)
                        .setOnUpdate(t =>
                        {
                            var color = image.color;
                            color.a = t;
                            image.color = color;
                        });
                }
                case BlendAlphaTarget.SpriteRenderer when
                    gameObjectToAnimate.TryGetComponent<SpriteRenderer>(out var spriteRenderer):
                {
                    var from = spriteRenderer.color.a;
                    return LeanTween.value(gameObjectToAnimate, from, to, duration)
                        .setOnUpdate(t =>
                        {
                            var color = spriteRenderer.color;
                            color.a = t;
                            spriteRenderer.color = color;
                        });
                }
                default:
                    return null;
            }
        }
    }
}