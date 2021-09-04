using System.Collections.Generic;

namespace ScreensService.Stacks
{
    public class ScreensStack<TScreen, TScreenConstraint, TScreenKey>
        : IScreensStack<TScreen, TScreenConstraint>
        where TScreen : TScreenConstraint
    {
        private readonly IScreensService<TScreenConstraint, TScreenKey> _screensService;
        private readonly TScreenKey _screenKey;
        private readonly Stack<TScreen> _screensStack;

        public int Count => _screensStack.Count;

        public ScreensStack(IScreensService<TScreenConstraint, TScreenKey> screensService,
            TScreenKey screenKey)
        {
            _screensService = screensService;
            _screenKey = screenKey;
            _screensStack = new Stack<TScreen>();
        }

        public TScreen Peek()
        {
            return _screensStack.Peek();
        }

        public bool TryPeek(out TScreen screen)
        {
            screen = default;
            if (Count > 0)
            {
                screen = Peek();
            }

            return Count > 0;
        }

        public TScreen Push()
        {
            var screen = _screensService.GetScreen<TScreen>(_screenKey);
            //TODO increase canvas priority? probably move to abstract method
            _screensStack.Push(screen);

            return screen;
        }

        public void Pop()
        {
            var screen = _screensStack.Pop();
            _screensService.DisposeScreen(screen, _screenKey);
        }
    }
}