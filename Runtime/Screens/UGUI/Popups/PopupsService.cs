using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public class PopupsService<TPopupBase, TPopupsSource> : MonoBehaviour, IPopupsService<TPopupBase>
        where TPopupBase : Component, IScreen, IPooledScreen, ISelfCloseableScreen<TPopupBase>
        where TPopupsSource : IPooledSource<TPopupBase>
    {
        public event Action<TPopupBase, ScreenState> StateChanged;

        [SerializeField]
        private TPopupsSource _source;

        [SerializeField]
        private RectTransform _root;

        private readonly Dictionary<Type, TPopupBase> _openedPopups = new();
        private ScreenOpenCloseHandle<TPopupBase> _closeHandle;

        public int OpenedPopupsCount => _openedPopups.Count;

        protected virtual void Awake()
        {
            _closeHandle = new ScreenOpenCloseHandle<TPopupBase>(this);
        }

        protected virtual void OnDestroy()
        {
            ClearEventHandlers();
        }

        public TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase
        {
            return _source.Get<TPopup>();
        }

        public bool TryGet<TPopup>(out TPopup popup)
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

        public void Open(TPopupBase popupBase, bool skipAnimation)
        {
            popupBase.CloseHandle = _closeHandle;

            if (!popupBase.IsClosedOrClosing())
            {
                return;
            }

            var type = popupBase.GetType();

            var popupTransform = popupBase.transform;
            popupTransform.SetParent(_root);
            popupTransform.SetAsLastSibling();

            _openedPopups.Add(type, popupBase);

            StateChanged?.Invoke(popupBase, ScreenState.Opening);

            popupBase.Open(() =>
            {
                StateChanged?.Invoke(popupBase, ScreenState.Opened);
            }, skipAnimation);
        }

        public void Close(TPopupBase popupBase, bool skipAnimation)
        {
            if (popupBase.IsOpenedOrOpening())
            {
                _openedPopups.Remove(popupBase.GetType());

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
        }

        public IEnumerator<TPopupBase> GetEnumerator()
        {
            return ((IEnumerable<TPopupBase>)_openedPopups.Values).GetEnumerator();
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
