using DG.Tweening;
using UnityEngine;

namespace Common.Core.TweenAnim.TweenAnimations {
    public class TweenProviderRotation : ITweenProvider {
        public Tween GetTween(TweenAnimData data) {
            var transform = data.TargetTransform;
            var initRotation = transform.rotation;
            var settings = data.Settings;

            Vector3 targetRotation;

            if (settings.StartType == TweenStartType.To)
                targetRotation = initRotation.eulerAngles + settings.TargetVector;
            else
            {
                transform.rotation = Quaternion.Euler(initRotation.eulerAngles + settings.TargetVector);
                targetRotation = initRotation.eulerAngles;
            }

            Tween tween = settings.AnimType == TweenAnimType.Rotation
                ? transform.DORotate(targetRotation, settings.Duration)
                : transform.DOLocalRotate(targetRotation, settings.Duration);

            return tween;
        }
    }
}