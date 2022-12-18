namespace Dre0Dru.Screens.Stacks
{
    public interface IScreenStacks
    {
        void AddStack<TScreenStack>(TScreenStack screenStack)
            where TScreenStack : class, IScreenStack;

        TScreenStack Get<TScreenStack>()
            where TScreenStack : class, IScreenStack;

        void RemoveStack<TScreenStack>(TScreenStack screenStack)
            where TScreenStack : class, IScreenStack;
    }
}
