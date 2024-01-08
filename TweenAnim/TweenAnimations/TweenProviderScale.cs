using DG.Tweening;
using UnityEngine;

namespace Common.Core.TweenAnim.TweenAnimations 
{
    public sealed class TweenProviderScale : ITweenProvider {

        public Tween GetTween(TweenAnimData data) {
            var transform = data.TargetTransform;
            var initScale = transform.localScale;
            var settings = data.Settings;

            Vector3 targetScale;

            if (settings.StartType == TweenStartType.To)
                targetScale = initScale + settings.TargetVector;
            else
            {
                transform.localScale = initScale + settings.TargetVector;
                targetScale = initScale;
            }

            Tween tween = transform.DOScale(targetScale, settings.Duration);
            return tween;
        }
    }
}