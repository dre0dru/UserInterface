using System.Collections.Generic;

namespace Dre0Dru.UI.Screens
{
    //TODO split into CreationSource and DestroySource (instead of ScreenDestroyStrategy)?
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
}
