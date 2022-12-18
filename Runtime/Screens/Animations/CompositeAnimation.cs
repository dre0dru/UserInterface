using System;
using UnityEngine;

namespace Dre0Dru.Screens.Animations
{
    [Serializable, AddTypeMenu("Composite Animation")]
    public class CompositeAnimation : IScreenAnimation
    {
        [SerializeReference, SubclassSelector]
        private IScreenAnimation _mainAnimation = new EmptyAnimation();

        [SerializeReference, SubclassSelector]
        private IScreenAnimation[] _additionalAnimations = Array.Empty<IScreenAnimation>();

        public void Play(Action onComplete)
        {
            _mainAnimation.Play(onComplete);

            foreach (var animation in _additionalAnimations)
            {
                animation.Play(null);
            }
        }

        public void Complete()
        {
            _mainAnimation.Complete();

            foreach (var animation in _additionalAnimations)
            {
                animation.Complete();
            }
        }
    }
}
