using System.Collections.Generic;

namespace Dre0Dru.UI.Screens
{
    public interface IScreensSource<TScreenBase> : IEnumerable<TScreenBase>
        where TScreenBase : IScreen
    {
        TScreen Get<TScreen>()
            where TScreen : TScreenBase;
    }

    public interface IScreenPrefabsSource<TPrefab> : IEnumerable<TPrefab>
        where TPrefab : IScreen
    {
        TScreen GetPrefab<TScreen>()
            where TScreen : TPrefab;
    }

    public interface IPooledSource<TScreenBase> : IScreensSource<TScreenBase>
        where TScreenBase : IScreen, IPooledScreen
    {
        void ReturnToPool(TScreenBase screen);
    }
}
