﻿using System;
using Dre0Dru.UI.Screens.UGUI.Animations;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI
{
    public class ScreenBase : MonoBehaviour, IScreen
    {
        [SerializeField]
        private ScreenAnimation _animation;

        [SerializeField]
        private ScreenState _state = ScreenState.Closed;

        public ScreenState State
        {
            get => _state;
            private set
            {
                _state = value;
                StateChanged?.Invoke(_state);
            }
        }

        protected ScreenAnimation Animation => _animation;

        public event Action<ScreenState> StateChanged;

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        void IScreen.Open(Action onComplete, bool skipAnimation)
        {
            State = ScreenState.Opening;
            OnOpenStarted();

            if (skipAnimation)
            {
                OpenFinishedLocal();
            }
            else
            {
                _animation.InterruptCurrentAnimation();
                _animation.PlayOpenAnimation(OpenFinishedLocal);
            }

            void OpenFinishedLocal()
            {
                _state = ScreenState.Opened;
                OnOpenFinished();

                onComplete?.Invoke();
            }
        }

        void IScreen.Close(Action onComplete, bool skipAnimation)
        {
            State = ScreenState.Closing;
            OnCloseStarted();

            if (skipAnimation)
            {
                CloseFinishedLocal();
            }
            else
            {
                _animation.InterruptCurrentAnimation();
                _animation.PlayCloseAnimation(CloseFinishedLocal);
            }

            void CloseFinishedLocal()
            {
                State = ScreenState.Closed;
                OnCloseFinished();

                onComplete?.Invoke();
            }
        }

        protected virtual void OnOpenStarted()
        {
        }

        protected virtual void OnOpenFinished()
        {
        }

        protected virtual void OnCloseStarted()
        {
        }

        protected virtual void OnCloseFinished()
        {
        }

        protected void ClearEventHandlers()
        {
            StateChanged = null;
        }
    }
}
