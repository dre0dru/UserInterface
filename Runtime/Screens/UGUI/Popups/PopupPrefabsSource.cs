using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    //TODO как отдельный абстрактный компонент методом Get
    //как для из SO
    //так и для панелей в сцене
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
