using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public class PopupBasev2 : ScreenBasev2, IPopup<PopupBasev2>
    {
        [SerializeField]
        private bool _isPooled;

        public bool IsPooled => _isPooled;

        private ICloseHandle<PopupBasev2> CloseHandle { get; set; }

        ICloseHandle<PopupBasev2> ISelfCloseableScreen<PopupBasev2>.CloseHandle
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
