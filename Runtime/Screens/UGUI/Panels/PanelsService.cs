using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Panels
{
    public class PanelsService<TPanelBase, TPanelsSource> : MonoBehaviour, IPanelsService<TPanelBase>
        where TPanelBase : IScreen
        where TPanelsSource : IScreensSource<TPanelBase>
    {
        public event Action<TPanelBase, ScreenState> StateChanged;

        [SerializeField]
        private TPanelsSource _source;

        protected TPanelsSource Source => _source;

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        public virtual TPanel Get<TPanel>()
            where TPanel : TPanelBase
        {
            var panel = _source.Get<TPanel>();

            return panel;
        }

        public virtual void Open(TPanelBase popupBase, bool skipAnimation = false)
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

        public virtual void Close(TPanelBase popupBase, bool skipAnimation = false)
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

        protected void ClearEventHandlers()
        {
            StateChanged = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
