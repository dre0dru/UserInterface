using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Panels
{
    public abstract class PanelsServiceBase<TPanelBase> : MonoBehaviour, IPanelsService<TPanelBase>
        where TPanelBase : ScreenBase
    {
        public abstract event Action<TPanelBase> OpenStarted;
        public abstract event Action<TPanelBase> OpenFinished;
        public abstract event Action<TPanelBase> CloseStarted;
        public abstract event Action<TPanelBase> CloseFinished;

        public abstract TPanel Get<TPanel>()
            where TPanel : TPanelBase;

        public abstract TPanel Open<TPanel>(bool skipAnimation)
            where TPanel : TPanelBase;

        public abstract void Open(TPanelBase panelBase, bool skipAnimation);

        public abstract void Close<TPanel>(bool skipAnimation)
            where TPanel : TPanelBase;

        public abstract void Close(TPanelBase panelBase, bool skipAnimation);

        public abstract void CloseAll(bool skipAnimation);

        public abstract void CloseAllExcept<TPanel>(bool skipAnimation)
            where TPanel : TPanelBase;

        public abstract void CloseAllExcept(bool skipAnimation, params Type[] except);

        public abstract IEnumerator<TPanelBase> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
