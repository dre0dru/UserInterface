using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dre0Dru.Screens.Stacks
{
    public class SimpleScreenStack<TScreenBase> : IScreenStackPush<TScreenBase>, IScreenStackPop, 
        IScreenStackPopAll, IScreenStackCallbacks<TScreenBase>
        where TScreenBase : MonoBehaviour, IScreen, IAnimatedScreen, IStackedScreen
    {
        private readonly Transform _root;
        private readonly Stack<TScreenBase> _stack;

        public event Action<TScreenBase> OnPushStart;
        public event Action<TScreenBase> OnPushFinish;
        public event Action<TScreenBase> OnPopStart;
        public event Action<TScreenBase> OnPopFinish;

        public SimpleScreenStack(Transform root)
        {
            _root = root;
            _stack = new Stack<TScreenBase>();
        }

        public void Push(TScreenBase screen)
        {
            _stack.Push(screen);
            screen.ScreenStackPop = this;

            var screenTransform = screen.transform;
            screenTransform.SetParent(_root, false);
            screenTransform.SetAsLastSibling();
            screen.Open();

            OnPushStart?.Invoke(screen);

            screen.PlayOpenAnimation(() =>
            {
                OnPushFinish?.Invoke(screen);
            });
        }

        public void Pop()
        {
            if (!_stack.TryPop(out var screen))
            {
                return;
            }

            PopScreen(screen);
        }

        public void PopAll()
        {
            while (_stack.TryPop(out var screen))
            {
                PopScreen(screen);
            }
        }

        private void PopScreen(TScreenBase screen)
        {
            screen.ScreenStackPop = null;

            OnPopStart?.Invoke(screen);

            screen.PlayCloseAnimation(() =>
            {
                OnPopFinish?.Invoke(screen);

                screen.Close();
                
                //TODO can pass Pool as dependency and return screen there
                Object.Destroy(screen.gameObject);
            });
        }
    }
}
