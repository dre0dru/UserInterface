using System;
using System.Collections;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Animations
{
    /// <summary>
    /// Some animations that reset ui state one frame after it was instantiated
    /// may cause flickering, it is one of possible ways to solve this problem
    /// </summary>
    public class ScreenHideOneFrameAnimationDecorator : ScreenAnimation
    {
        [SerializeField]
        private ScreenAnimation _screenAnimation;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        public override void PlayOpenAnimation(Action onComplete)
        {
            SetCanvasGroupActive(false);
            _screenAnimation.PlayOpenAnimation(onComplete);
            StartCoroutine(SetRootActiveAfterOneFrame());
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            _screenAnimation.PlayCloseAnimation(onComplete);
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
            _screenAnimation.InterruptCurrentAnimation(complete);
        }

        private void SetCanvasGroupActive(bool isActive)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.alpha = isActive ? 1 : 0;
            }
        }

        private IEnumerator SetRootActiveAfterOneFrame()
        {
            yield return null;

            SetCanvasGroupActive(true);
        }
    }
}
