#if DOTWEEN_ENABLED
using System;
using DG.Tweening;
using Dre0Dru.Tweening;
using UnityEngine;

namespace Dre0Dru.Screens.Animations
{
    [Serializable, AddTypeMenu("DOTween Sequence")]
    public class DOTweenSequence : IScreenAnimation
    {
        [SerializeField]
        private TweenSequence _tweenSequence;

        private Sequence _sequence;
        
        public void Play(Action onComplete)
        {
            _tweenSequence.ResetToInitialValues();

            _sequence ??= _tweenSequence.Build();
            _sequence.OnComplete(new TweenCallback(onComplete));

            _sequence.Play();
        }

        public void Complete()
        {
            _sequence.Complete(true);
        }
    }
}
#endif
