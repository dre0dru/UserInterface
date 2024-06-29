using System;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Animations
{
    public abstract class ScreenAnimation : MonoBehaviour
    {
        public abstract void PlayOpenAnimation(Action onComplete);
        public abstract void PlayCloseAnimation(Action onComplete);
        public abstract void InterruptCurrentAnimation(bool complete = true);
    }
}
