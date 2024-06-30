using System;
using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Screens.UGUI.Sources;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Panels
{
    public class PanelsService<TPanelBase> : MonoBehaviour, IPanelsService<TPanelBase>
        where TPanelBase : Component, IScreen
    {
        public event Action<TPanelBase, ScreenState> StateChanged;

        [SerializeField]
        private ScreensSceneSource<TPanelBase> _source;

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        public TPanel Get<TPanel>()
            where TPanel : TPanelBase
        {
            return _source.Get<TPanel>();
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
            return ((IEnumerable<TPanelBase>)_source).GetEnumerator();
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
