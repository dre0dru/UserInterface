using System;
using Dre0Dru.UI.Screens.UGUI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI
{
    //Canvas per screen (https://unity.com/en/how-to/unity-ui-optimization-tips)
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class ScreenBase : MonoBehaviour, IScreen
    {
        [Header("Settings")]
        [SerializeField]
        private Canvas _canvas;

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
