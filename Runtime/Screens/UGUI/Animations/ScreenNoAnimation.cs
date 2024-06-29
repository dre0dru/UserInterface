using System;

namespace Dre0Dru.Screens.UGUI.Animations
{
    public class ScreenNoAnimation : ScreenAnimation
    {
        public override void PlayOpenAnimation(Action onComplete)
        {
            onComplete?.Invoke();
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            onComplete?.Invoke();
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
        }
    }
}
