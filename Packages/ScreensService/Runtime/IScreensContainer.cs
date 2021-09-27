using System.Collections.Generic;

namespace ScreensService
{
    public interface IScreensContainer<TScreenConstraint, TScreenKey>
    {
        IEnumerable<TScreenKey> Keys { get; }

        TScreen GetOrCreateScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetOrCreateScreen(TScreenKey screenKey);
    }
}