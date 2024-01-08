using DG.Tweening;
using UnityEngine;

namespace Common.Core.TweenAnim.TweenAnimations 
{
    public sealed class TweenProviderPosition : ITweenProvider {
        public Tween GetTween(TweenAnimData data) {
            var transform = data.TargetTransform;
            var initPos = transform.position;
            var settings = data.Settings;

            Vector3 targetPosition;

            if (settings.StartType == TweenStartType.To)          
                targetPosition = initPos + settings.TargetVector;
            else
            {
                transform.position = initPos + settings.TargetVector;
                targetPosition = initPos;
            }

            Tween tween = settings.AnimType == TweenAnimType.Position
                ? transform.DOMove(targetPosition, settings.Duration)
                : transform.DOLocalMove(targetPosition, settings.Duration);

            return tween;
        }
    }
}