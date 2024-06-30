using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Popups
{
    public class PopupBase : ScreenBase, IPooledScreen, ISelfCloseableScreen<PopupBase>
    {
        [SerializeField]
        private bool _isPooled;

        public bool IsPooled => _isPooled;

        private ICloseHandle<PopupBase> CloseHandle { get; set; }

        ICloseHandle<PopupBase> ISelfCloseableScreen<PopupBase>.CloseHandle
        {
            set => CloseHandle = value;
        }

        void IPooledScreen.ResetOnReturnToPool()
        {
            ClearEventHandlers();
        }

        protected virtual void OnReturnToPool()
        {
        }

        public void Close(bool skipAnimation = false)
        {
            CloseHandle.Close(this, skipAnimation);
        }
    }
}
