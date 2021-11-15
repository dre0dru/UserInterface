using System;
using System.Collections.Generic;
using System.Linq;
using Screens.Container;
using UnityEngine;

namespace Tests.Scripts
{
    [CreateAssetMenu(fileName = "ScreensSource", menuName = "SO/ScreensSource")]
    public class SoScreensSource : PrefabScreensSource<string, ScreenBase>
    {
        [Serializable]
        public struct KeyToScreen
        {
            public string Key;
            public ScreenBase Screen;
        }

        [SerializeField]
        private KeyToScreen[] _screens;

        public override IEnumerable<string> Keys => _screens.Select(screen => screen.Key);
        public override ScreenBase Get(string screenKey)
        {
            return _screens.First(screen => screen.Key.Equals(screenKey)).Screen;
        }
    }
}
