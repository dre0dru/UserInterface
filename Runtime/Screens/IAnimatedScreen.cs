using System;

namespace Dre0Dru.Screens
{
    public interface IAnimatedScreen
    {
        void PlayOpenAnimation(Action onComplete);

        void PlayCloseAnimation(Action onComplete);
    }
}
