using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Panels
{
    public class PanelsService<TPanelBase, TPanelsSource> : MonoBehaviour, IPanelsService<TPanelBase>
        where TPanelBase : IScreen, ISelfOpenableScreen<TPanelBase>, ISelfCloseableScreen<TPanelBase>
        where TPanelsSource : IScreensSource<TPanelBase>
    {
        public event Action<TPanelBase, ScreenState> StateChanged;

        [SerializeField]
        private TPanelsSource _source;

        private ScreenOpenCloseHandle<TPanelBase> _openCloseHandle;

        protected virtual void Awake()
        {
            _openCloseHandle = new ScreenOpenCloseHandle<TPanelBase>(this);
        }

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        public TPanel Get<TPanel>()
            where TPanel : TPanelBase
        {
            var panel = _source.Get<TPanel>();

            panel.OpenHandle = _openCloseHandle;
            panel.CloseHandle = _openCloseHandle;

            return panel;
        }

        public void Open(TPanelBase popupBase, bool skipAnimation)
        {
            if (!popupBase.IsClosedOrClosing())
            {
                return;
            }

            StateChanged?.Invoke(popupBase, ScreenState.Opening);

            popupBase.Open(() =>
            {
                StateChanged?.Invoke(popupBase, ScreenState.Opened);
            }, skipAnimation);
        }

        public void Close(TPanelBase popupBase, bool skipAnimation)
        {
            if (!popupBase.IsOpenedOrOpening())
            {
                return;
            }

            StateChanged?.Invoke(popupBase, ScreenState.Closing);

            popupBase.Close(() =>
            {
                StateChanged?.Invoke(popupBase, ScreenState.Closed);
            }, skipAnimation);
        }

        public IEnumerator<TPanelBase> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        private void ClearEventHandlers()
        {
            StateChanged = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
