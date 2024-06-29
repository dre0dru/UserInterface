﻿using System;
using Dre0Dru.Screens.UGUI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.Screens.UGUI.Popups
{
    //Canvas per screen (https://unity.com/en/how-to/unity-ui-optimization-tips)
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class PopupBase : MonoBehaviour
    {
        public event Action OpenStarted;
        public event Action OpenFinished;
        public event Action CloseStarted;
        public event Action CloseFinished;

        [Header("Settings")]
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private ScreenAnimation _animation;

        [SerializeField]
        private bool _isPooled;

        [SerializeField]
        private ScreenState _state = ScreenState.Closed;

        public Canvas Canvas => _canvas;

        public ScreenState State
        {
            get => _state;
            internal set => _state = value;
        }

        protected ScreenAnimation Animation => _animation;

        internal Action<bool> CloseAction { private get; set; }

        internal bool IsPooled => _isPooled;

        protected void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
        }

        protected internal void InterruptCurrentAnimation()
        {
            _animation.InterruptCurrentAnimation();
        }

        protected internal void Close(bool skipAnimation)
        {
            CloseAction?.Invoke(skipAnimation);
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

        protected internal virtual void OnReset()
        {
        }

        internal void Open(Action onComplete, bool skipAnimation)
        {
            State = ScreenState.Opening;
            OnOpenStarted();
            OpenStarted?.Invoke();

            if (skipAnimation)
            {
                OpenFinishedLocal();
            }
            else
            {
                _animation.PlayOpenAnimation(OpenFinishedLocal);
            }

            void OpenFinishedLocal()
            {
                State = ScreenState.Opened;
                OnOpenFinished();
                OpenFinished?.Invoke();
                onComplete?.Invoke();
            }
        }

        internal void Close(Action onComplete, bool skipAnimation)
        {
            State = ScreenState.Closing;
            OnCloseStarted();
            CloseStarted?.Invoke();

            if (skipAnimation)
            {
                CloseFinishedLocal();
            }
            else
            {
                _animation.PlayCloseAnimation(CloseFinishedLocal);
            }

            void CloseFinishedLocal()
            {
                State = ScreenState.Closed;
                OnCloseFinished();
                CloseFinished?.Invoke();

                onComplete?.Invoke();
            }
        }

        protected internal void ClearEventHandlers()
        {
            OpenStarted = null;
            OpenFinished = null;
            CloseStarted = null;
            CloseFinished = null;
        }
    }
}