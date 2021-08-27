using UnityEngine;

namespace ScreensService
{
    public interface IScreensService<TScreenConstraint, in TScreenKey>
        where TScreenConstraint : Component
    {
        TScreen GetScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetScreen(TScreenKey screenKey);
    }
}