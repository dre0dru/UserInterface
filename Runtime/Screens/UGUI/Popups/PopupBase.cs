using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Popups
{
    public class PopupBase : ScreenBase, IPooledScreen, ISelfCloseableScreen
    {
        [SerializeField]
        private bool _isPooled;

        public bool IsPooled => _isPooled;

        private ICloseHandle CloseHandle { get; set; }

        ICloseHandle ISelfCloseableScreen.CloseHandle
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
            CloseHandle.Close(skipAnimation);
        }
    }
}
