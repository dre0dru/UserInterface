namespace Dre0Dru.Screens
{
    public interface IOpenHandle<in TScreenBase>
    {
        void Open(TScreenBase screen, bool skipAnimation = false);
    }
}
