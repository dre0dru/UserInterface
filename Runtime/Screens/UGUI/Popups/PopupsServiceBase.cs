using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public abstract class PopupsServiceBase<TPopupBase> : MonoBehaviour, IPopupsService<TPopupBase>
        where TPopupBase : PopupBase
    {
        public abstract event Action<TPopupBase> OpenStarted;
        public abstract event Action<TPopupBase> OpenFinished;
        public abstract event Action<TPopupBase> CloseStarted;
        public abstract event Action<TPopupBase> CloseFinished;

        public abstract event Action<int> OpenedCountChanged;
        public abstract int OpenedPopupsCount { get; }

        public abstract TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase;

        public abstract TScreen Open<TScreen>(bool skipAnimation)
            where TScreen : TPopupBase;

        public abstract void Open(TPopupBase popupBase, bool skipAnimation);

        public abstract void Close<TScreen>(bool skipAnimation)
            where TScreen : TPopupBase;

        public abstract void Close(TPopupBase popupBase, bool skipAnimation);

        public abstract void CloseAll(bool skipAnimation);

        public abstract void CloseAllExcept<TScreen>(bool skipAnimation)
            where TScreen : TPopupBase;

        public abstract void CloseAllExcept(bool skipAnimation, params Type[] except);

        public abstract bool IsOpened<TScreen>(out TScreen popup)
            where TScreen : TPopupBase;

        public abstract bool IsOpened<TScreen>()
            where TScreen : TPopupBase;

        public abstract IEnumerator<TPopupBase> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
