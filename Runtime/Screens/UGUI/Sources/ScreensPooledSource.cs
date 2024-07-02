using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public class ScreensPooledSource<TPooledScreen, TScreensSource> : ScreensSource<TPooledScreen>,
        IScreenDestroyStrategy<TPooledScreen>
        where TPooledScreen : Component, IScreen, IPooledScreen
        where TScreensSource : IScreenPrefabsSource<TPooledScreen>
    {
        [SerializeField]
        private RectTransform _poolRoot;

        [SerializeField]
        private RectTransform _screensRoot;

        [SerializeField]
        private TScreensSource _prefabsSource;

        private readonly List<TPooledScreen> _pooledPopups = new();

        public override TScreen Get<TScreen>()
        {
            var screen = _pooledPopups.SingleOrDefault(popup => popup.GetType() == typeof(TScreen)) as TScreen;

            if (screen == null)
            {
                var prefab = _prefabsSource.GetPrefab<TScreen>();
                screen = Instantiate(prefab);
            }

            var screenTransform = screen.transform;
            screenTransform.SetParent(_screensRoot);
            screenTransform.SetAsLastSibling();

            return screen;
        }

        public void Destroy(TPooledScreen screen)
        {
            if (screen.IsPooled)
            {
                ReturnToPool(screen);
            }
            else
            {
                Destroy(screen.gameObject);
            }
        }

        public override IEnumerator<TPooledScreen> GetEnumerator()
        {
            return ((IEnumerable<TPooledScreen>)_pooledPopups).GetEnumerator();
        }

        private void ReturnToPool(TPooledScreen screen)
        {
            screen.ResetOnReturnToPool();
            screen.transform.SetParent(_poolRoot);
            _pooledPopups.Add(screen);
        }
    }
}
