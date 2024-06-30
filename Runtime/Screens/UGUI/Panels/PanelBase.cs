namespace Dre0Dru.UI.Screens.UGUI.Panels
{
    public class PanelBase : ScreenBase, ISelfOpenableScreen, ISelfCloseableScreen
    {
        private IOpenHandle OpenHandle { get; set; }
        private ICloseHandle CloseHandle { get; set; }

        IOpenHandle ISelfOpenableScreen.OpenHandle
        {
            set => OpenHandle = value;
        }

        ICloseHandle ISelfCloseableScreen.CloseHandle
        {
            set => CloseHandle = value;
        }

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
