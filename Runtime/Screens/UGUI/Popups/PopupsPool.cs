using System.Collections.Generic;
using System.Linq;
using Dre0Dru.Screens.UGUI.Popups;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Pools
{
    public class PopupsPool<TPopupBase> : MonoBehaviour
        where TPopupBase : PopupBase
    {
        private readonly List<TPopupBase> _pooledPopups = new();

        public bool TryGet<TScreen>(out TScreen screen)
            where TScreen : TPopupBase
        {
            screen = _pooledPopups.SingleOrDefault(popup => popup.GetType() == typeof(TScreen)) as TScreen;

            return screen != null;
        }

        public void Return(TPopupBase screen)
        {
            _pooledPopups.Add(screen);
        }
    }
}
