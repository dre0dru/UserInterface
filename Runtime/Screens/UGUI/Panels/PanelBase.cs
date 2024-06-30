namespace Dre0Dru.UI.Screens.UGUI.Panels
{
    public class PanelBase : ScreenBase, ISelfOpenableScreen<PanelBase>, ISelfCloseableScreen<PanelBase>
    {
        private IOpenHandle<PanelBase> OpenHandle { get; set; }
        private ICloseHandle<PanelBase> CloseHandle { get; set; }


        IOpenHandle<PanelBase> ISelfOpenableScreen<PanelBase>.OpenHandle
        {
            set => OpenHandle = value;
        }

        ICloseHandle<PanelBase> ISelfCloseableScreen<PanelBase>.CloseHandle
        {
            set => CloseHandle = value;
        }

        public void Open(bool skipAnimation = false)
        {
            OpenHandle.Open(this, skipAnimation);
        }

        public void Close(bool skipAnimation = false)
        {
            CloseHandle.Close(this, skipAnimation);
        }
    }
}
