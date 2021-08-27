using UnityEngine;

namespace ScreensService
{
    public interface IScreensContainerFacade<TScreenConstraint, TScreenKey> : IScreensContainer<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        void AddScreensContainer(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer);
        void RemoveScreensContainer(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer);
    }
}