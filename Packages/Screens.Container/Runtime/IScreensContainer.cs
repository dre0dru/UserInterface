using System.Collections.Generic;

namespace Screens.Container
{
    public interface IScreensContainer<TScreenKey, TScreenConstraint>
    {
        IEnumerable<TScreenKey> Keys { get; }

        TScreen Get<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint Get(TScreenKey screenKey);
    }
}