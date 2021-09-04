using System;

namespace ScreensService
{
    public interface IScreensContainer<TScreenConstraint, in TScreenKey> : IDisposable
    {
        TScreen GetOrCreateScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetOrCreateScreen(TScreenKey screenKey);
        
        void DisposeScreen(TScreenConstraint screen, TScreenKey screenKey);
    }
}