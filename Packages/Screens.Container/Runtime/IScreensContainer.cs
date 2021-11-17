using System.Collections.Generic;

namespace Screens.Container
{
    //TODO separate interface for full async api with Async Source supported
    //Async source is either addressables or async wrapper around existing sources?
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