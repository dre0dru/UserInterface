using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public class ScreensInstantiateSource<TScreenBase, TScreensSource> : ScreensSource<TScreenBase>
        where TScreenBase : Component, IScreen
        where TScreensSource : IScreenPrefabsSource<TScreenBase>
    {
        [SerializeField]
        private RectTransform _root;

        [SerializeField]
        private TScreensSource _prefabsSource;

        public override TScreen Get<TScreen>()
        {
            var prefab = _prefabsSource.GetPrefab<TScreen>();
            return Instantiate(prefab, _root, false);
        }

        public override IEnumerator<TScreenBase> GetEnumerator()
        {
            return _prefabsSource.GetEnumerator();
        }

        public void Destroy(TScreenBase screen)
        {
            Destroy(screen.gameObject);
        }
    }
}
