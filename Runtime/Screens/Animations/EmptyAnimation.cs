using System;

namespace Dre0Dru.Screens.Animations
{
    [Serializable, AddTypeMenu("Empty Animation")]
    public class EmptyAnimation : IScreenAnimation
    {
        public void Play(Action onComplete)
        {
            onComplete?.Invoke();
        }

        public void Complete()
        {
        }
    }
}
