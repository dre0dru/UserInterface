using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    public class ScreensPooledSource<TPooledScreen> : ScreensSource<TPooledScreen>
        where TPooledScreen : Component, IScreen, IPooledScreen
    {
        [SerializeField]
        private RectTransform _poolRoot;

        [SerializeField]
        private ScreensSource<TPooledScreen> _screensSource;

        private readonly List<TPooledScreen> _pooledPopups = new();

        public override TScreen Get<TScreen>()
        {
            var screen = _pooledPopups.SingleOrDefault(popup => popup.GetType() == typeof(TScreen)) as TScreen;

            if (screen == null)
            {
                var prefab = _screensSource.Get<TScreen>();
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
