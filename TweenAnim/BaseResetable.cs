using UnityEngine;
using UnityEngine.UI;

namespace Common.Core.TweenAnim {
    public class BaseResetable : MonoBehaviour, IResetable {
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private Vector3 _initialScale;

        private float _initialImageAlpha;

        protected CanvasGroup CanvasGroup;
        protected Image TargetImage;

        private float _initialCanvasGroupAlpha;

        protected Transform myTransform;


        protected virtual void Awake() {
            myTransform = transform;
            _initialPosition = myTransform.position;
            _initialRotation = myTransform.rotation;
            _initialScale = myTransform.localScale;

            TargetImage = GetComponent<Image>();
            if (TargetImage != null) {
                _initialImageAlpha = TargetImage.color.a;
            }

            CanvasGroup = GetComponent<CanvasGroup>();
            if (CanvasGroup != null) {
                _initialCanvasGroupAlpha = CanvasGroup.alpha;
            }
            
        }



        public virtual void Reset() {
            if(myTransform == null) return;
            
            myTransform.position = _initialPosition;
            myTransform.rotation = _initialRotation;
            myTransform.localScale = _initialScale;

            if (TargetImage != null) {
                var imageColor = TargetImage.color;
                imageColor.a = _initialImageAlpha;
                TargetImage.color = imageColor;
            }

            if (CanvasGroup != null) {
                CanvasGroup.alpha = _initialCanvasGroupAlpha;
            }
        }
    }
}