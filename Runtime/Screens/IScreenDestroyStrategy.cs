namespace Dre0Dru.UI.Screens
{
    public interface IScreenDestroyStrategy<in TScreenBase>
        where TScreenBase : IScreen
    {
        void Destroy(TScreenBase screen);
    }
}