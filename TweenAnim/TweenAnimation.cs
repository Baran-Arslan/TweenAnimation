using UnityEngine;
using UnityEngine.UI;

namespace Common.Core.TweenAnim {
    [System.Serializable]
    public class TweenAnimation {
        
        private readonly Transform myTransform;
        
        private readonly Image _targetImage;
        private readonly CanvasGroup _canvasGroup;

        public TweenAnimation(Transform transform, CanvasGroup canvasGroup, Image targetImage) {
            myTransform = transform;
            _targetImage = targetImage;
            _canvasGroup = canvasGroup;
        }
        
        public TweenAnimData GetTweenAnimData(TweenTypeSettings tweenTypeSettings) {
            var tweenSettings = tweenTypeSettings.SettingsType == TweenSettingsType.Preset 
                ? tweenTypeSettings.Preset.presetSettings 
                : tweenTypeSettings.AnimCustomSettings;
            

            var tweenData = new TweenAnimData(myTransform, tweenSettings, _targetImage, _canvasGroup);
            return tweenData;
        }
        
    }
}