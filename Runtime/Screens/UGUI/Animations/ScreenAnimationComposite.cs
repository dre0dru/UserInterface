using System;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Animations
{
    public class ScreenAnimationComposite : ScreenAnimation
    {
        [SerializeField]
        private ScreenAnimation _mainAnimation;

        [SerializeField]
        private ScreenAnimation[] _additionalAnimations;

        public override void PlayOpenAnimation(Action onComplete)
        {
            _mainAnimation.PlayOpenAnimation(onComplete);

            foreach (var additionalAnimation in _additionalAnimations)
            {
                additionalAnimation.PlayOpenAnimation(null);
            }
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            _mainAnimation.PlayCloseAnimation(onComplete);

            foreach (var additionalAnimation in _additionalAnimations)
            {
                additionalAnimation.PlayCloseAnimation(null);
            }
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
            _mainAnimation.InterruptCurrentAnimation(complete);

            foreach (var additionalAnimation in _additionalAnimations)
            {
                additionalAnimation.InterruptCurrentAnimation(complete);
            }
        }
    }
}
