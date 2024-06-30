namespace Dre0Dru.UI.Screens
{
    public class ScreenOpenCloseHandle<TScreenBase> : ICloseHandle<TScreenBase>, IOpenHandle<TScreenBase>
        where TScreenBase : IScreen
    {
        private readonly IScreensService<TScreenBase> _screensService;

        public ScreenOpenCloseHandle(IScreensService<TScreenBase> screensService)
        {
            _screensService = screensService;
        }

        public void Open(TScreenBase screen, bool skipAnimation = false)
        {
            _screensService.Open(screen, skipAnimation);
        }

        public void Close(TScreenBase screen, bool skipAnimation = false)
        {
            _screensService.Close(screen, skipAnimation);
        }
    }
}
