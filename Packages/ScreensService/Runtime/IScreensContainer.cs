using System;
using UnityEngine;

namespace ScreensService
{
    public interface IScreensContainer<TScreenConstraint, in TScreenKey> : IDisposable
        where TScreenConstraint : Component
    {
        TScreen LoadScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint LoadScreen(TScreenKey screenKey);

        // void UnloadScreen(TScreenKey screenKey);

        // bool IsScreenLoaded(TScreenKey screenKey);
     
        //TODO for screens container facade
        // bool CanLoadScreen
    }
}