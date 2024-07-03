namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    public class PanelBase : CanvasPanelBase, ISelfOpenableScreen, ISelfCloseableScreen
    {
        public IOpenHandle OpenHandle { private get; set; }

        public ICloseHandle CloseHandle { private get; set; }

        public void Open(bool skipAnimation = false)
        {
            OpenHandle.Open(skipAnimation);
        }

        public void Close(bool skipAnimation = false)
        {
            CloseHandle.Close(skipAnimation);
        }
    }
}
