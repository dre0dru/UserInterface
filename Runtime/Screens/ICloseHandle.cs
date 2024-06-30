namespace Dre0Dru.UI.Screens
{
    public interface ICloseHandle<in TScreenBase>
    {
        void Close(TScreenBase screen, bool skipAnimation = false);
    }
}
