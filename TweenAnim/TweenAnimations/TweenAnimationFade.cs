using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Core.TweenAnim.TweenAnimations {

    public interface IHaveAlpha {
        public void SetAlpha(float alpha);
        public float GetAlpha();
        public Tween GetTween(float targetAlpha, float duration) {
            return DOTween.To(GetAlpha, SetAlpha, targetAlpha, duration);
        }
    }
    
    public sealed class TweenAnimationFade : ITweenProvider {
        public Tween GetTween(TweenAnimData data) {
            var settings = data.Settings;
            IHaveAlpha alphaObject = GetAlphaObject(data);
            Tween tween;

            if (settings.StartType == TweenStartType.To) {
                tween = alphaObject.GetTween(settings.TargetAlpha, settings.Duration);
            }
            else {
                float initialAlpha = alphaObject.GetAlpha();
                alphaObject.SetAlpha(settings.TargetAlpha);
                tween = alphaObject.GetTween(initialAlpha, settings.Duration);
            }
            return tween;
        }

        private static IHaveAlpha GetAlphaObject(TweenAnimData data) {
            if(data.TargetImage != null) {
                return new ImageAlpha(data.TargetImage);
            }
            else if(data.TargetCanvasGroup != null) {
                return new CanvasGroupAlpha(data.TargetCanvasGroup);
            }
            else {
                Debug.LogError("No alpha object found");
                return null;
            }
        }


    }
    internal sealed class ImageAlpha : IHaveAlpha {
        private readonly Image _image;
        public ImageAlpha(Image image) {
            _image = image;
        }
        public void SetAlpha(float alpha) {
            var color = _image.color;
            color.a = alpha;
            _image.color = color;
        }

        public float GetAlpha() {
            return _image.color.a;
        }
    }
    internal sealed class CanvasGroupAlpha : IHaveAlpha {
        private readonly CanvasGroup _canvasGroup;
        public CanvasGroupAlpha(CanvasGroup canvasGroup) {
            _canvasGroup = canvasGroup;
        }
        public void SetAlpha(float alpha) {
            _canvasGroup.alpha = alpha;
        }
        public float GetAlpha() {
            return _canvasGroup.alpha;
        }
    }
    
}