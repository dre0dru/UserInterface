using UnityEngine;

namespace ScreensService
{
    public interface IQueuedScreensService<in TScreenConstraint>
        where TScreenConstraint : Component
    {
        // ScreenQueue<TScreen> GetScreenQueue<TScreen>()
            // where TScreen : TScreenConstraint;
    }
}