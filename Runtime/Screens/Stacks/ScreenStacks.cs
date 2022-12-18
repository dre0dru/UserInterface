using System;
using System.Collections.Generic;
using Dre0Dru.Collections;

namespace Dre0Dru.Screens.Stacks
{
    public class ScreenStacks : IScreenStacks
    {
        private readonly Dictionary<Type, IScreenStack> _screenStacks;

        public ScreenStacks()
        {
            _screenStacks = new Dictionary<Type, IScreenStack>();
        }

        public void AddStack<TScreenStack>(TScreenStack screenStack)
            where TScreenStack : class, IScreenStack
        {
            _screenStacks.Add(screenStack);
        }

        public TScreenStack Get<TScreenStack>()
            where TScreenStack : class, IScreenStack
        {
            _screenStacks.Get(out TScreenStack screenStack);

            return screenStack;
        }

        public void RemoveStack<TScreenStack>(TScreenStack screenStack)
            where TScreenStack : class, IScreenStack
        {
            _screenStacks.Remove<IScreenStack, TScreenStack>();
        }
    }
}
