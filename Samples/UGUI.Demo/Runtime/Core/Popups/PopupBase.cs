using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public class PopupBase : CanvasPopupBase, IPooledScreen, ISelfCloseableScreen
    {
        [SerializeField]
        private bool _isPooled;

        public bool IsPooled => _isPooled;

        //TODO вынести это в Core asmdef и сделать internal
        public ICloseHandle CloseHandle { private get; set; }

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
