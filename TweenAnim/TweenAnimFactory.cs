using Common.Core.TweenAnim.TweenAnimations;
using UnityEngine;

namespace Common.Core.TweenAnim {
    internal static class TweenAnimFactory {
        public static ITweenProvider GetTweenAnimInstance(TweenAnimType animType)
        {
            switch (animType)
            {
                case TweenAnimType.Position:
                    return new TweenProviderPosition();
                case TweenAnimType.LocalPosition:
                    return new TweenProviderPosition();
                case TweenAnimType.Rotation:
                    return new TweenProviderRotation();
                case TweenAnimType.LocalRotation:
                    return new TweenProviderPosition();
                case TweenAnimType.Scale:
                    return new TweenProviderScale();
                case TweenAnimType.FadeAlpha:
                    return new TweenAnimationFade();
                case TweenAnimType.Shake:
                    return new TweenAnimationShake();
                
                default:
                    Debug.LogError("Unsupported TweenAnimType");
                    return null;
            }
        }
    }
}