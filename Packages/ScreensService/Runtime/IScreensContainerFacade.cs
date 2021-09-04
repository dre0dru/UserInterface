namespace ScreensService
{
    public interface IScreensContainerFacade<TScreenConstraint, TScreenKey> : IScreensContainer<TScreenConstraint, TScreenKey>
    {
        void Add(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer);
        void Remove(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer);
    }
}