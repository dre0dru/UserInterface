using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public class ScreenPrefabsCollectionSource<TScreenBase, TScreensSource> : MonoBehaviour, IScreenPrefabsSource<TScreenBase>
        where TScreenBase : Component, IScreen
        where TScreensSource : IScreenPrefabsSource<TScreenBase>
    {
        [SerializeField]
        private TScreensSource _source;

        public TScreen GetPrefab<TScreen>()
            where TScreen : TScreenBase
        {
            return _source.GetPrefab<TScreen>();
        }

        public IEnumerator<TScreenBase> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
