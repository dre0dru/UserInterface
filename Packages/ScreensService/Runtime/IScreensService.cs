namespace ScreensService
{
    public interface IScreensService<TScreenConstraint, in TScreenKey>
    {
        TScreen GetScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetScreen(TScreenKey screenKey);

        void DisposeScreen(TScreenConstraint screen, TScreenKey screenKey);
    }
}