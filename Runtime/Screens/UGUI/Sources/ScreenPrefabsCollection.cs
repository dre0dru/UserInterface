using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public class ScreenPrefabsCollection<TScreenBase> : ScriptableObject, IScreenPrefabsSource<TScreenBase>
        where TScreenBase : Component, IScreen
    {
        [SerializeField]
        private List<TScreenBase> _prefabs;

        public TScreen GetPrefab<TScreen>()
            where TScreen : TScreenBase
        {
            return _prefabs.Single(screen => screen.GetType() == typeof(TScreen)) as TScreen;
        }

        public IEnumerator<TScreenBase> GetEnumerator()
        {
            return ((IEnumerable<TScreenBase>)_prefabs).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
