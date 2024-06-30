namespace Dre0Dru.Screens
{
    public interface ICloseHandle<in TScreenBase>
    {
        void Close(TScreenBase screen, bool skipAnimation = false);
    }
}
