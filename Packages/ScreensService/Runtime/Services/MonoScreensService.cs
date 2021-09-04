using UnityEngine;

namespace ScreensService.Services
{
    public class MonoScreensService<TScreenConstraint, TScreenKey> : IScreensService<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        private readonly IScreensContainer<TScreenConstraint, TScreenKey> _screensContainer;

        #if UNITY_2020_3_OR_NEWER
        [UnityEngine.Scripting.RequiredMember]
        #endif
        public MonoScreensService(IScreensContainer<TScreenConstraint, TScreenKey> screensContainer)
        {
            _screensContainer = screensContainer;
        }

        public TScreen GetScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            return _screensContainer.GetOrCreateScreen<TScreen>(screenKey);
        }

        public TScreenConstraint GetScreen(TScreenKey screenKey)
        {
            return _screensContainer.GetOrCreateScreen(screenKey);
        }

        public void DisposeScreen(TScreenConstraint screen, TScreenKey screenKey)
        {
            _screensContainer.DisposeScreen(screen, screenKey);
        }
    }
}