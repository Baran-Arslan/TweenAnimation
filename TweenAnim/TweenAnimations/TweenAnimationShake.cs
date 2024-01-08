using DG.Tweening;

namespace Common.Core.TweenAnim.TweenAnimations {
    public class TweenAnimationShake : ITweenProvider 
    {
        public Tween GetTween(TweenAnimData data) {
            var transform = data.TargetTransform;
            var settings = data.Settings;
            var shakesettings = settings.ShakeSettings;
            Tween tween = null;

            if (shakesettings.ShakePosition) {
                tween = transform.DOShakePosition(settings.Duration, settings.TargetVector, shakesettings.Vibrato,
                    shakesettings.Randomness);
            }

            if (shakesettings.ShakeRotation) {
                tween = transform.DOShakeRotation(settings.Duration, settings.TargetVector, shakesettings.Vibrato,
                    shakesettings.Randomness);
            }

            if (shakesettings.ShakeScale) {
                tween = transform.DOShakeScale(settings.Duration, settings.TargetVector, shakesettings.Vibrato,
                    shakesettings.Randomness);
            }

            return tween;
        }
    }
}