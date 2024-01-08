using System.Collections.Generic;
using Common.Core.TweenAnim.Scriptable_Object;
using DG.Tweening;
using iCareGames.Common.Core.AudioSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Core.TweenAnim
{
    [System.Serializable]
    public sealed class TweenAnimSettings {
        [BoxGroup("General Settings")]
        public TweenAnimType AnimType = TweenAnimType.Position;
        [BoxGroup("General Settings")]
        [EnumToggleButtons] public TweenStartType StartType = TweenStartType.To;
        [BoxGroup("General Settings")]
        public Ease EaseMode = Ease.Linear;
        [BoxGroup("General Settings")]
        [ShowIf("NeedLoopType")] public LoopType LoopType = LoopType.Yoyo;
        [BoxGroup("General Settings")]
        public int Loops = 1;
        [BoxGroup("General Settings")]
        public float Duration = 1;
        [BoxGroup("General Settings")]
        public bool IgnoreTimeScale = true;
        
        [BoxGroup("Animation Settings")]
        [ShowIf("NeedVector")]
        public Vector3 TargetVector;
        [BoxGroup("Animation Settings")]
        [Range(0,1), ShowIf("NeedAlpha")]
        public float TargetAlpha = 1;
        [BoxGroup("Animation Settings")]
        [ShowIf("NeedShakeSettings")]
        public ShakeSettings ShakeSettings;
        
        
        private bool NeedVector() {
            return
                AnimType is
                    TweenAnimType.Position or
                    TweenAnimType.LocalPosition or
                    TweenAnimType.Rotation or
                    TweenAnimType.Shake or 
                    TweenAnimType.LocalRotation or
                    TweenAnimType.Scale;
        }
        private bool NeedAlpha() {
            return AnimType is TweenAnimType.FadeAlpha;
        }
        private bool NeedLoopType() {
            return Loops > 1;
        }
        private bool NeedShakeSettings() {
            return AnimType is TweenAnimType.Shake;
        }
    }

    [System.Serializable]
    public sealed class TweenAnimHolder {
        [TabGroup("Animation Settings")]
        public AudioSO AudioToPlay;
        [TabGroup("Animation Settings")]
        public List<TweenTypeSettings> TweenAnimations;
        
        
        [TabGroup("Events")]
        public bool DestroyGameObjectOnFinish;
        [ShowIf("DestroyGameObjectOnFinish"), TabGroup("Events"), EnumToggleButtons]
        public DestroyType DestroyTypeOnFinish = DestroyType.Destroy;
        [Space(30)]
        [TabGroup("Events")]
        public UnityEvent OnTweenStart;
        [TabGroup("Events")]
        public UnityEvent OnLongestTweenFinish;
    }

    [System.Serializable]
    public sealed class TweenTypeSettings {
        [TabGroup("Settings Type")]
        public TweenSettingsType SettingsType = TweenSettingsType.Preset;
        [HideIf("SettingsType", TweenSettingsType.Preset)]
        [TabGroup("Settings Type")]
        public TweenAnimSettings AnimCustomSettings;
        [ShowIf("SettingsType", TweenSettingsType.Preset), InlineEditor]
        [TabGroup("Settings Type")]
        public TweenAnimSO Preset;
    }

    [System.Serializable]
    public sealed class ShakeSettings {
        public int Vibrato = 10;
        public float Randomness = 1;
        public bool ShakePosition = true;
        public bool ShakeRotation = true;
        public bool ShakeScale = true;
    }
}
