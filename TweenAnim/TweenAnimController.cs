using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Core.TweenAnim
{
    public class TweenAnimController : BaseResetable {
        
        [PropertyOrder(10)] public TweenAnimHolder TweenAnimHolder;

        [ContextMenu("Play")]
        public void Play() {
            TweenAnimHolder.Play(myTransform, CanvasGroup, TargetImage);
        }

        [ContextMenu("Reset and Play")]
        public void ResetAndPlay() {
            Reset();
            Play();
        }
    }
}
