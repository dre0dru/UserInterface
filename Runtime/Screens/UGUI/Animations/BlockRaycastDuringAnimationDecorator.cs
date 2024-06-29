using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.Screens.UGUI.Animations
{
    public class BlockRaycastDuringAnimationDecorator : ScreenAnimation
    {
        [SerializeField]
        private ScreenAnimation _screenAnimation;

        [SerializeField]
        private Graphic _raycastBlocker;

        public override void PlayOpenAnimation(Action onComplete)
        {
            _raycastBlocker.raycastTarget = true;
            _screenAnimation.PlayOpenAnimation(() =>
            {
                onComplete?.Invoke();
                _raycastBlocker.raycastTarget = false;
            });
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            _raycastBlocker.raycastTarget = true;
            _screenAnimation.PlayCloseAnimation(onComplete);
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
            _screenAnimation.InterruptCurrentAnimation(complete);
        }
    }
}
