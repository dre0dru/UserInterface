using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public class PopupPrefabsSource<TPopupBase> : ScriptableObject
        where TPopupBase : PopupBase
    {
        [SerializeField]
        private List<TPopupBase> _popupPrefabs;

        public TPopup FindPrefab<TPopup>()
            where TPopup : TPopupBase =>
            _popupPrefabs.Single(popup => popup.GetType() == typeof(TPopup)) as TPopup;
    }
}
