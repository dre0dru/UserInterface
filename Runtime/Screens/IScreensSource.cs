using System.Collections.Generic;

namespace Dre0Dru.Screens
{
    //TODO сделать бы как-то имплементацию так, чтобы просто подменой источника
    //менялось поведение
    //тип пул или нет, со сцены или из префаба

    //TODO а пока как минимум сделать реализации на генерик суорсе с констрейнтом
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
