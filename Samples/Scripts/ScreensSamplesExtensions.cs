using Dre0Dru.Screens.Stacks;

namespace Dre0Dru.UserInterface.Samples.Scripts
{
    public static class ScreensSamplesExtensions
    {
        public static TScreen CreateAndPush<TScreen, TStack>(this SampleScreenStacks screenStacks)
            where TScreen : ScreenBase 
            where TStack : class, IScreenStack, IScreenStackPush<ScreenBase>
        {
            var screen = screenStacks.Create<TScreen>();
            var stack = screenStacks.Get<TStack>();
            
            stack.Push(screen);

            return screen;
        }
    }
}
