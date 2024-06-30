namespace Dre0Dru.Screens
{
    public interface IScreensServiceLayers<out TScreenService, in TKey, TScreenBase>
        where TScreenService : IScreensService<TScreenBase>
        where TScreenBase : IScreen
    {
        TScreenService Get(TKey key);
    }
}
