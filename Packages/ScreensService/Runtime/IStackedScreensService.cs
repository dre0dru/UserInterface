using UnityEngine;

namespace ScreensService
{
    public interface IStackedScreensService<in TScreenConstraint>
        where TScreenConstraint : Component
    {
        // ScreenStack<TScreen> GetScreenStack<TScreen>()
            // where TScreen : TScreenConstraint;

    }
}