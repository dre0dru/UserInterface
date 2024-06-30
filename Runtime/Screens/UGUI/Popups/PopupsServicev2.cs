using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dre0Dru.Screens.UGUI.Sources;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public class PopupsServicev2<TPopupBase> : MonoBehaviour, IPopupsServicev2<TPopupBase>
        where TPopupBase : Component, IPopup<TPopupBase>
    {
        public event Action<TPopupBase, ScreenState> StateChanged;

        [SerializeField]
        private ScreensPoolSource<TPopupBase> _pool;

        [SerializeField]
        private RectTransform _root;

        private readonly Dictionary<Type, TPopupBase> _openedPopups = new();
        private PopupCloseHandle<TPopupBase> _closeHandle;

        public int OpenedPopupsCount => _openedPopups.Count;

        private void Awake()
        {
            _closeHandle = new PopupCloseHandle<TPopupBase>(this);
        }

        private void OnDestroy()
        {
            ClearEventHandlers();
        }

        public TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase
        {
            var popup = _pool.Get<TPopup>();

            popup.CloseHandle = _closeHandle;

            return popup;
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
                        _pool.Return(popupBase);
                    }
                    else
                    {
                        Destroy(popupBase.gameObject);
                    }
                }, skipAnimation);
            }
        }


        //TODO можно как экстеншн + просто Get как экстеншн
        public bool IsOpened<TPopup>()
            where TPopup : TPopupBase
        {
            return _openedPopups.ContainsKey(typeof(TPopup));
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
