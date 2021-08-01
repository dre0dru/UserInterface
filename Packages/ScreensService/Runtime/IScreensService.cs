using UnityEngine;

namespace ScreensService
{
    public interface IScreensService<in TScreenConstraint>
        where TScreenConstraint : Component
    {
        TScreen GetScreen<TScreen>()
            where TScreen : TScreenConstraint;
    }
}