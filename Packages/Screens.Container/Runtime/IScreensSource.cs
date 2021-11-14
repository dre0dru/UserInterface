using System.Collections.Generic;

namespace Screens.Container
{
    public interface IScreensSource<TScreenKey, out TScreenConstraint>
    {
        IEnumerable<TScreenKey> Keys { get; }

        TScreenConstraint Get(TScreenKey screenKey);
    }
}
