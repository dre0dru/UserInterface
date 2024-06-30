using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    public class ScreenPrefabsFromCollectionSource<TScreenBase> : ScreensSource<TScreenBase>
        where TScreenBase : Component, IScreen
    {
        [SerializeField]
        private ScreenPrefabsCollection<TScreenBase> _collection;

        public override TScreen Get<TScreen>()
        {
            return _collection.Get<TScreen>();
        }
    }
}
