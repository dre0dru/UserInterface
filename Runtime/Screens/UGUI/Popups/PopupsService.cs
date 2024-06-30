using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Popups
{
    //TODO do not make openable/closeable by default, make separate implementation
    //TODO also do not make pooled by default
    public class PopupsService<TPopupBase, TPopupsSource> : MonoBehaviour, IPopupsService<TPopupBase>
        where TPopupBase : Component, IScreen, IPooledScreen, ISelfCloseableScreen
        where TPopupsSource : IPooledSource<TPopupBase>
    {
        public event Action<TPopupBase, ScreenState> StateChanged;

        [SerializeField]
        private TPopupsSource _source;

        [SerializeField]
        private RectTransform _root;

        private readonly Dictionary<Type, TPopupBase> _openedPopups = new();

        public int OpenedPopupsCount => _openedPopups.Count;

        protected TPopupsSource Source => _source;

        protected RectTransform Root => _root;

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        public virtual TPopup Create<TPopup>()
            where TPopup : TPopupBase
        {
            var popup = _source.Get<TPopup>();

            popup.CloseHandle = new ScreenOpenCloseHandle<TPopupBase>(this);

            return popup;
        }

        public virtual bool TryGet<TPopup>(out TPopup popup)
            where TPopup : TPopupBase
        {
            if (_openedPopups.TryGetValue(typeof(TPopup), out var popupBase))
            {
                popup = popupBase as TPopup;
                return true;
            }

            popup = default;
            return false;
        }

        public virtual void Open(TPopupBase popupBase, bool skipAnimation)
        {
            var type = popupBase.GetType();

            var popupTransform = popupBase.transform;
            popupTransform.SetParent(_root);
            popupTransform.SetAsLastSibling();

            if (!_openedPopups.TryAdd(type, popupBase))
            {
                return;
            }

            StateChanged?.Invoke(popupBase, ScreenState.Opening);

            popupBase.Open(() =>
            {
                StateChanged?.Invoke(popupBase, ScreenState.Opened);
            }, skipAnimation);
        }

        public virtual void Close(TPopupBase popupBase, bool skipAnimation)
        {
            var type = popupBase.GetType();

            if (!_openedPopups.Remove(type))
            {
                return;
            }

            StateChanged?.Invoke(popupBase, ScreenState.Closing);

            popupBase.Close(() =>
            {
                StateChanged?.Invoke(popupBase, ScreenState.Closed);

                if (popupBase.IsPooled)
                {
                    _source.ReturnToPool(popupBase);
                }
                else
                {
                    Destroy(popupBase.gameObject);
                }
            }, skipAnimation);
        }

        public IEnumerator<TPopupBase> GetEnumerator()
        {
            return ((IEnumerable<TPopupBase>)_openedPopups.Values).GetEnumerator();
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
