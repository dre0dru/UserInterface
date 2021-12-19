using System.Collections.Generic;

namespace Screens.Container
{
    //Screens queue
    //Screens stack
    //Async source is either addressables or async wrapper around existing sources?
    public interface IScreensContainer<TScreenKey, TScreenConstraint>
    {
        ICollection<TScreenKey> Keys { get; }

        TScreenConstraint Instantiate(TScreenKey screenKey);

        TScreen Instantiate<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;

        TScreenConstraint GetInstance(TScreenKey screenKey);

        TScreen GetInstance<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint;
    }
}