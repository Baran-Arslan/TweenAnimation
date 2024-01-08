using DG.Tweening;
using iCareGames.Common.Core.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Core.TweenAnim {
    public static class TweenAnimPlayer {

        public static void Play(this TweenAnimHolder holder, Transform transform, CanvasGroup canvasGroup, Image targetImage) {
            holder.OnTweenStart?.Invoke();
            
            if (holder.AudioToPlay != null) AudioManager.PlaySfx(holder.AudioToPlay);

            var list = holder.TweenAnimations;

            Tween longestTween = null;
            float longestDuration = 0f;

            foreach (var animSetting in list) {
                var anim = new TweenAnimation(transform, canvasGroup, targetImage);
                var tweenData = anim.GetTweenAnimData(animSetting);
                var tweenProvider = TweenAnimFactory.GetTweenAnimInstance(tweenData.Settings.AnimType);
                var tween = CreateAndConfigureTween(tweenProvider, tweenData);

                if (tweenData.Settings.Duration > longestDuration) {
                    longestDuration = tweenData.Settings.Duration;
                    longestTween = tween;
                }
                tween.Play();
            }

            longestTween?.OnComplete(() => 
            {
                holder.OnLongestTweenFinish?.Invoke();
                if (!holder.DestroyGameObjectOnFinish) return;
                switch (holder.DestroyTypeOnFinish) {
                    case DestroyType.Destroy: Object.Destroy(transform.gameObject); break;
                    case DestroyType.Disable: transform.gameObject.SetActive(false); break;
                }
            });
            
        }

        private static Tween CreateAndConfigureTween(ITweenProvider tweenProvider, TweenAnimData tweenData) {
            var tween = tweenProvider.GetTween(tweenData);
            tween.SetEase(tweenData.Settings.EaseMode)
                .SetLoops(tweenData.Settings.Loops, tweenData.Settings.LoopType)
                .SetUpdate(tweenData.Settings.IgnoreTimeScale)
                .SetAutoKill(true);

            return tween;
        }
    }
}