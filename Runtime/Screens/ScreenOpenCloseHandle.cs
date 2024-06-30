namespace Dre0Dru.UI.Screens
{
    public class ScreenOpenCloseHandle<TScreenBase> : ICloseHandle, IOpenHandle
        where TScreenBase : IScreen
    {
        private readonly IScreensService<TScreenBase> _screensService;
        private readonly TScreenBase _screen;

        public ScreenOpenCloseHandle(IScreensService<TScreenBase> screensService)
        {
            _screensService = screensService;
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
