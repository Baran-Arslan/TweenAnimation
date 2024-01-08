using DG.Tweening;

namespace Common.Core.TweenAnim {
    public interface ITweenProvider 
    {
        public Tween GetTween(TweenAnimData data);
    }
}