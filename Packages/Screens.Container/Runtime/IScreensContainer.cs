using System.Collections.Generic;

namespace Screens.Container
{
    public interface IScreensContainer<TScreenKey, TScreenConstraint>
    {
        IEnumerable<TScreenKey> Keys { get; }

        TScreenConstraint Instantiate(TScreenKey screenKey);

        TScreen Instantiate<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetInstance(TScreenKey screenKey);

        TScreen GetInstance<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;
    }
}