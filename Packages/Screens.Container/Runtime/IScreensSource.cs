using System.Collections.Generic;

namespace Screens.Container
{
    public interface IScreensSource<TScreenKey, TScreenConstraint>
    {
        bool IsInstanced { get; }
        IEnumerable<KeyToScreen<TScreenKey, TScreenConstraint>> Screens { get; }
    }
}
