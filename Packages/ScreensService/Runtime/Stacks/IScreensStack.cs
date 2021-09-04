namespace ScreensService.Stacks
{
    public interface IScreensStack<TScreen, TScreenConstraint>
        where TScreen : TScreenConstraint
    {
        int Count { get; }
        TScreen Peek();
        bool TryPeek(out TScreen screen);
        TScreen Push();
        void Pop();
    }
}