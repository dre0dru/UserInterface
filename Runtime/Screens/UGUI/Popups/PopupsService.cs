using System;
using System.Collections.Generic;
using System.Linq;
using Dre0Dru.Screens.UGUI.Pools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dre0Dru.Screens.UGUI.Popups
{
    //TODO все-таки попробовать единой имплементацией? через некий ScreenSource<T>
    //TODO или может общий класс вида ScreenServiceBase, особенно когда перенесу генерики в
    // экстеншены вынесу
    //а там просто переопределить Get метод и Release. для попапов - новый или из пула + дестрой или вернуть
    //для панелей - со сцены и ничего не делаем после
    //TODO перевести все сервисы на интерфейс без базового попапа
    //пулы и прочее можно сделать как отедльные интерфейсы для попапа, мол базовый IScreen + IPooledScreen
    //но тут надо подумать, что делать с internal методами, которые set
    //хотелось бы, чтобы к ним доступа не было
    public class PopupsService<TPopupBase> : PopupsServiceBase<TPopupBase>
        where TPopupBase : PopupBase
    {
        public override event Action<TPopupBase> OpenStarted;
        public override event Action<TPopupBase> OpenFinished;
        public override event Action<TPopupBase> CloseStarted;
        public override event Action<TPopupBase> CloseFinished;

        public override event Action<int> OpenedCountChanged;

        [SerializeField]
        private PopupPrefabsSource<TPopupBase> _source;

        [SerializeField]
        private PopupsPool<TPopupBase> _pool;

        [SerializeField]
        private RectTransform _root;

        private readonly Dictionary<Type, TPopupBase> _openedPopups = new();

        public override int OpenedPopupsCount => _openedPopups.Count;

        private void OnDestroy()
        {
            ClearEventHandlers();
        }

        public override TPopup Instantiate<TPopup>()
        {
            if (!_pool.TryGet<TPopup>(out var popup))
            {
                var prefab = _source.FindPrefab<TPopup>();
                popup = Object.Instantiate(prefab, _root);
            }

            popup.CloseAction = (skipAnimation) => { Close(popup, skipAnimation); };

            return popup;
        }

        public override TPopup Open<TPopup>(bool skipAnimation)
        {
            var popup = Instantiate<TPopup>();

            Open(popup, skipAnimation);

            return popup;
        }

        public override void Open(TPopupBase popupBase, bool skipAnimation)
        {
            var type = popupBase.GetType();

            popupBase.InterruptCurrentAnimation();
            popupBase.transform.SetAsLastSibling();

            _openedPopups.Add(type, popupBase);

            OpenStarted?.Invoke(popupBase);
            OpenedCountChanged?.Invoke(OpenedPopupsCount);

            popupBase.Open(() =>
            {
                OpenFinished?.Invoke(popupBase);
            }, skipAnimation);
        }

        public override void Close<TPopup>(bool skipAnimation)
        {
            if (_openedPopups.TryGetValue(typeof(TPopup), out var popup))
            {
                Close(popup, skipAnimation);
            }
        }

        public override void Close(TPopupBase popupBase, bool skipAnimation)
        {
            if (popupBase.IsOpenedOrOpening())
            {
                popupBase.InterruptCurrentAnimation();

                _openedPopups.Remove(popupBase.GetType());

                CloseStarted?.Invoke(popupBase);
                OpenedCountChanged?.Invoke(OpenedPopupsCount);

                popupBase.Close(() =>
                {
                    CloseFinished?.Invoke(popupBase);

                    popupBase.ClearEventHandlers();
                    popupBase.OnReset();

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

        public override void CloseAll(bool skipAnimation)
        {
            foreach (var openedPopup in _openedPopups.Values)
            {
                Close(openedPopup, skipAnimation);
            }
        }

        public override void CloseAllExcept<TPopup>(bool skipAnimation)
        {
            foreach (var kvp in _openedPopups)
            {
                if (kvp.Key == typeof(TPopup))
                {
                    continue;
                }

                Close(kvp.Value, skipAnimation);
            }
        }

        public override void CloseAllExcept(bool skipAnimation, params Type[] except)
        {
            foreach (var kvp in _openedPopups)
            {
                if (except.Contains(kvp.Key))
                {
                    continue;
                }

                Close(kvp.Value, skipAnimation);
            }
        }

        public override bool IsOpened<TPopup>(out TPopup popup)
        {
            if (_openedPopups.TryGetValue(typeof(TPopup), out var popupBase))
            {
                popup = popupBase as TPopup;
                return true;
            }

            popup = default;
            return false;
        }

        public override bool IsOpened<TPopup>()
        {
            return _openedPopups.ContainsKey(typeof(TPopup));
        }

        public override IEnumerator<TPopupBase> GetEnumerator()
        {
            return ((IEnumerable<TPopupBase>)_openedPopups).GetEnumerator();
        }

        private void ClearEventHandlers()
        {
            OpenStarted = null;
            OpenFinished = null;
            CloseStarted = null;
            CloseFinished = null;
            OpenedCountChanged = null;
        }
    }
}
