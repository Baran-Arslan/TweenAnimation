using UnityEngine;
using UnityEngine.UI;

namespace Common.Core.TweenAnim {
    public struct TweenAnimData {
        public readonly Image TargetImage;
        public readonly CanvasGroup TargetCanvasGroup;
        public readonly Transform TargetTransform;
        public readonly TweenAnimSettings Settings;
        
        public TweenAnimData(Transform targetTransform, TweenAnimSettings settings, Image targetImage = null, CanvasGroup targetCanvas = null)
        {
            TargetImage = targetImage;
            TargetTransform = targetTransform;
            Settings = settings;
            TargetCanvasGroup = targetCanvas;
        }
    }
}