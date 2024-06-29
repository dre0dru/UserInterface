#if ANIMATION_SEQUENCER

using System;
using BrunoMikoski.AnimationSequencer;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Animations
{
    public class ScreenAnimationSequencer : ScreenAnimation
    {
        [SerializeField]
        private AnimationSequencerController _openAnimationSequencer;

        [SerializeField]
        private AnimationSequencerController _closeAnimationSequencer;

        public override void PlayOpenAnimation(Action onComplete)
        {
            _openAnimationSequencer.Play(onComplete);
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            _closeAnimationSequencer.Play(onComplete);
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
            _openAnimationSequencer.Complete(complete);
            _closeAnimationSequencer.Complete(complete);
        }
    }
}

#endif
