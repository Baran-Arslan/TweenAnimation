using UnityEngine;

namespace Common.Core.TweenAnim.Scriptable_Object
{
    [CreateAssetMenu(fileName = "New Preset", menuName = "iCare UI/TweenAnim Preset")]
    public sealed class TweenAnimSO : ScriptableObject
    {
        public TweenAnimSettings presetSettings;
    }
}
