using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Panels
{
    public class PanelsService<TPanelBase> : PanelsServiceBase<TPanelBase>
        where TPanelBase : ScreenBase
    {
        public override event Action<TPanelBase> OpenStarted;
        public override event Action<TPanelBase> OpenFinished;
        public override event Action<TPanelBase> CloseStarted;
        public override event Action<TPanelBase> CloseFinished;

        [SerializeField]
        private PanelsSceneSource<TPanelBase> _source;

        private void OnDestroy()
        {
            ClearEventHandlers();
        }

        public override TPanel Get<TPanel>()
        {
            var panelBase = _source.Get<TPanel>();
            panelBase.CloseAction = (skipAnimation) => { Close(panelBase, skipAnimation); };

            return panelBase;
        }

        public override TPanel Open<TPanel>(bool skipAnimation)
        {
            var panelBase = Get<TPanel>();

            Open(panelBase, skipAnimation);

            return panelBase;
        }

        public override void Open(TPanelBase popupBase, bool skipAnimation)
        {
            popupBase.InterruptCurrentAnimation();
            popupBase.transform.SetAsLastSibling();

            OpenStarted?.Invoke(popupBase);

            popupBase.Open(() =>
            {
                OpenFinished?.Invoke(popupBase);
            }, skipAnimation);
        }

        public override void Close<TPanel>(bool skipAnimation)
        {
            var panelBase = Get<TPanel>();

            Close(panelBase, skipAnimation);
        }

        public override void Close(TPanelBase popupBase, bool skipAnimation)
        {
            if (popupBase.IsOpenedOrOpening())
            {
                popupBase.InterruptCurrentAnimation();

                CloseStarted?.Invoke(popupBase);

                popupBase.Close(() =>
                {
                    CloseFinished?.Invoke(popupBase);
                }, skipAnimation);
            }
        }

        public override void CloseAll(bool skipAnimation)
        {
            foreach (var panelBase in _source)
            {
                Close(panelBase, skipAnimation);
            }
        }

        public override void CloseAllExcept<TPanel>(bool skipAnimation)
        {
            foreach (var panelBase in _source)
            {
                if (panelBase.GetType() == typeof(TPanel))
                {
                    continue;
                }

                Close(panelBase, skipAnimation);
            }
        }

        public override void CloseAllExcept(bool skipAnimation, params Type[] except)
        {
            foreach (var panelBase in _source)
            {
                if (except.Contains(panelBase.GetType()))
                {
                    continue;
                }

                Close(panelBase, skipAnimation);
            }
        }

        public override IEnumerator<TPanelBase> GetEnumerator()
        {
            return ((IEnumerable<TPanelBase>)_source).GetEnumerator();
        }

        private void ClearEventHandlers()
        {
            OpenStarted = null;
            OpenFinished = null;
            CloseStarted = null;
            CloseFinished = null;
        }
    }
}
