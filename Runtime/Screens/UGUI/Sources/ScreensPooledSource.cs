using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public class ScreensPooledSource<TPooledScreen, TScreensSource> : ScreensSource<TPooledScreen>
        where TPooledScreen : Component, IScreen, IPooledScreen
        where TScreensSource : IScreenPrefabsSource<TPooledScreen>
    {
        [SerializeField]
        private RectTransform _poolRoot;

        [SerializeField]
        private TScreensSource _prefabsSource;

        private readonly List<TPooledScreen> _pooledPopups = new();

        public override TScreen Get<TScreen>()
        {
            var screen = _pooledPopups.SingleOrDefault(popup => popup.GetType() == typeof(TScreen)) as TScreen;

            if (screen == null)
            {
                var prefab = _prefabsSource.GetPrefab<TScreen>();
                screen = Instantiate(prefab, _poolRoot);
            }

            return screen;
        }

        public void Return(TPooledScreen screen)
        {
            screen.ResetOnReturnToPool();
            screen.transform.SetParent(_poolRoot);
            _pooledPopups.Add(screen);
        }

        public override IEnumerator<TPooledScreen> GetEnumerator()
        {
            return ((IEnumerable<TPooledScreen>)_pooledPopups).GetEnumerator();
        }
    }
}
