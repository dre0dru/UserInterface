using UnityEngine;

namespace ScreensService.Services
{
    public class SingleScreensService<TScreenConstraint, TScreenKey> : IScreensService<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        private readonly IScreensContainer<TScreenConstraint, TScreenKey> _screensContainer;

        #if UNITY_2020_3_OR_NEWER
        [UnityEngine.Scripting.RequiredMember]
        #endif
        public SingleScreensService(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer)
        {
            _screensContainer = screensContainer;
        }

        public TScreen GetScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            return _screensContainer.LoadScreen<TScreen>(screenKey);
        }

        public TScreenConstraint GetScreen(TScreenKey screenKey)
        {
            return _screensContainer.LoadScreen(screenKey);
        }
    }
}