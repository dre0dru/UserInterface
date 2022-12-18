using System;

namespace Dre0Dru.Screens.Animations
{
    public interface IScreenAnimation
    {
        void Play(Action onComplete);

        void Complete();
    }
}
