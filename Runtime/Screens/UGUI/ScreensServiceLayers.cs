#if DRE0DRU_COLLECTIONS

using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Layers
{
    public class ScreensServiceLayers<TScreenService, TKey, TScreenBase> : MonoBehaviour, IScreensServiceLayers<TScreenService, TKey, TScreenBase>
        where TScreenService : IScreensService<TScreenBase>
        where TScreenBase : IScreen
    {
        [SerializeField]
        private UDictionary<TKey, TScreenService> _services;

        public TScreenService Get(TKey key)
        {
            return _services[key];
        }
    }
}

#endif
