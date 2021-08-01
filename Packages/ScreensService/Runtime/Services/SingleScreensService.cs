using UnityEngine;
using UnityEngine.Scripting;

namespace ScreensService.Services
{
    public class SingleScreensService<TScreenConstraint> : IScreensService<TScreenConstraint>
        where TScreenConstraint : Component
    {
        private readonly IScreensContainer<TScreenConstraint> _screensContainer;

        [RequiredMember]
        public SingleScreensService(IScreensContainer<TScreenConstraint> screensContainer)
        {
            _screensContainer = screensContainer;
        }

        public TScreen GetScreen<TScreen>()
            where TScreen : TScreenConstraint
        {
            return _screensContainer.LoadScreen<TScreen>();
        }
    }
}