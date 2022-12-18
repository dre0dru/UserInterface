using System;
using Dre0Dru.Screens;
using Dre0Dru.Screens.Animations;
using Dre0Dru.Screens.Stacks;
using UnityEngine;

namespace Dre0Dru.UserInterface.Samples.Scripts
{
    public class ScreenBase : MonoBehaviour, IAnimatedScreen, IScreen, IStackedScreen /*, ILayeredScreen<ScreenBase>*/
    {
        //TODO анимации лучше в отдельный компонент
        [SerializeReference, SubclassSelector]
        private IScreenAnimation _openAnimation = new EmptyAnimation();

        [SerializeReference, SubclassSelector]
        private IScreenAnimation _closeAnimation = new EmptyAnimation();

        // protected IScreenLayer<ScreenBase> _screenLayer;
        public IScreenStackPop ScreenStackPop { protected get; set; }

        void IAnimatedScreen.PlayOpenAnimation(Action onComplete)
        {
            _closeAnimation.Complete();

            OnOpenStarted();

            _openAnimation.Play(() =>
            {
                OnOpenFinished();
                onComplete?.Invoke();
            });
        }

        void IAnimatedScreen.PlayCloseAnimation(Action onComplete)
        {
            _openAnimation.Complete();

            OnCloseStarted();

            _closeAnimation.Play(() =>
            {
                OnCloseFinished();
                onComplete?.Invoke();
            });
        }

        // void ILayeredScreen<ScreenBase>.SetLayer(IScreenLayer<ScreenBase> screenLayer)
        // {
        //     _screenLayer = screenLayer;
        // }

        // protected void Close()
        // {
        //     _screenLayer.Close(this);
        // }

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

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

    }
}
