using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    public class ScreenPrefabsCollection<TScreenBase> : ScriptableObject
        where TScreenBase : Component, IScreen
    {
        [SerializeField]
        private List<TScreenBase> _prefabs;

        public TPopup Get<TPopup>()
            where TPopup : TScreenBase
        {
            return _prefabs.Single(popup => popup.GetType() == typeof(TPopup)) as TPopup;
        }
    }
}
