namespace Dre0Dru.UI.Screens
{
    public class ScreenOpenCloseHandle<TScreenBase> : ICloseHandle, IOpenHandle
        where TScreenBase : IScreen
    {
        private readonly TScreenBase _screen;
        private readonly IScreensService<TScreenBase> _screensService;

        public ScreenOpenCloseHandle(TScreenBase screen, IScreensService<TScreenBase> screensService)
        {
            _screensService = screensService;
            _screen = screen;
        }

        public void Open(bool skipAnimation = false)
        {
            _screensService.Open(_screen, skipAnimation);
        }

        public void Close(bool skipAnimation = false)
        {
            _screensService.Close(_screen, skipAnimation);
        }
    }
}
