using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    public class ScreensSceneSource<TScreenBase> : ScreensSource<TScreenBase>
        where TScreenBase : Component, IScreen
    {
        [SerializeField]
        private TScreenBase[] _sceneScreens;

        public override TScreen Get<TScreen>()
        {
            return _sceneScreens.Single(screen => screen.GetType() == typeof(TScreen)) as TScreen;
        }

        public override IEnumerator<TScreenBase> GetEnumerator()
        {
            return ((IEnumerable<TScreenBase>)_sceneScreens).GetEnumerator();
        }
    }
}
