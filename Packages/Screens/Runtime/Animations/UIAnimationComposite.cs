using DG.Tweening;
using UnityEngine;

namespace Screens.Animations
{
    public class UIAnimationComposite : UIAnimation
    {
        [SerializeField]
        private UIAnimation[] _uiAnimations;

        [SerializeField]
        private bool _sequentialAnimation;

        public override Tween Play()
        {
            return _sequentialAnimation ? _uiAnimations.AsSequence(this) : _uiAnimations.AsParallelSequence(this);
        }

        public override void Stop(bool complete)
        {
            DOTween.Kill(this, complete);
        }
    }
}
