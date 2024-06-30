namespace Dre0Dru.UI.Screens
{
    public interface IOpenHandle<in TScreenBase>
    {
        void Open(TScreenBase screen, bool skipAnimation = false);
    }
}
