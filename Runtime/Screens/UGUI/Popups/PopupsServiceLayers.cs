#if DRE0DRU_COLLECTIONS

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Popups
{
    //TODO locking unlocking layers via disabling graphic raycaster
    public class PopupsServiceLayers<TScreenService, TKey, TScreenBase> : ScreensServiceLayers<TScreenService, TKey, TScreenBase>, IPopupsService<TScreenBase>
        where TScreenService : IPopupsService<TScreenBase>
        where TScreenBase : IScreen
    {
        [SerializeField]
        private TKey _defaultLayerKey;

        public int OpenedPopupsCount => DefaultLayer.OpenedPopupsCount;

        private TScreenService DefaultLayer => Get(_defaultLayerKey);

        public event Action<TScreenBase, ScreenState> StateChanged
        {
            add => DefaultLayer.StateChanged += value;
            remove => DefaultLayer.StateChanged -= value;
        }

        public TPopup Instantiate<TPopup>()
            where TPopup : TScreenBase
        {
            return DefaultLayer.Instantiate<TPopup>();
        }

        public bool TryGet<TPopup>(out TPopup popup)
            where TPopup : TScreenBase
        {
            return DefaultLayer.TryGet<TPopup>(out popup);
        }

        public void Open(TScreenBase popupBase, bool skipAnimation)
        {
            DefaultLayer.Open(popupBase, skipAnimation);
        }

        public void Close(TScreenBase popupBase, bool skipAnimation)
        {
            DefaultLayer.Close(popupBase, skipAnimation);
        }

        public IEnumerator<TScreenBase> GetEnumerator()
        {
            return DefaultLayer.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

#endif
