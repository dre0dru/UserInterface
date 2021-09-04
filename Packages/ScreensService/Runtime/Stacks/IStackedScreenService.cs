namespace ScreensService.Stacks
{
    public interface IStackedScreenService<TScreenConstraint, in TScreenKey>
    {
        IScreensStack<TScreen, TScreenConstraint> GetScreensStack<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;
    }
}