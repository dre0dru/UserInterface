// #if DRE0DRU_COLLECTIONS
//
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Dre0Dru.Collections;
// using UnityEngine;
//
// namespace Dre0Dru.Screens.UGUI.Layers
// {
//     public class ScreenServiceLayers<TScreenService, TKey, TScreenBase> : MonoBehaviour, IScreenServiceLayers<TScreenService, TKey, TScreenBase>
//         where TScreenService : IScreensService<TScreenBase>
//     {
//         [SerializeField]
//         private TKey _defaultLayerKey;
//
//         [SerializeField]
//         private UDictionary<TKey, TScreenService> _services;
//
//         private IScreensService<TScreenBase> DefaultLayer => Get(_defaultLayerKey);
//
//         public event Action<TScreenBase> OpenStarted
//         {
//             add => DefaultLayer.OpenStarted += value;
//             remove => DefaultLayer.OpenStarted -= value;
//         }
//
//         public event Action<TScreenBase> OpenFinished
//         {
//             add => DefaultLayer.OpenFinished += value;
//             remove => DefaultLayer.OpenFinished -= value;
//         }
//
//         public event Action<TScreenBase> CloseStarted
//         {
//             add => DefaultLayer.CloseStarted += value;
//             remove => DefaultLayer.CloseStarted -= value;
//         }
//
//         public event Action<TScreenBase> CloseFinished
//         {
//             add => DefaultLayer.CloseFinished += value;
//             remove => DefaultLayer.CloseFinished -= value;
//         }
//
//         public TScreenService Get(TKey key)
//         {
//             return _services[key];
//         }
//
//         public TScreen Open<TScreen>(bool skipAnimation)
//             where TScreen : TScreenBase
//         {
//             return DefaultLayer.Open<TScreen>(skipAnimation);
//         }
//
//         public void Open(TScreenBase popupBase, bool skipAnimation)
//         {
//             DefaultLayer.Open(popupBase, skipAnimation);
//         }
//
//         public void Close<TScreen>(bool skipAnimation)
//             where TScreen : TScreenBase
//         {
//             DefaultLayer.Close<TScreen>(skipAnimation);
//         }
//
//         public void Close(TScreenBase popupBase, bool skipAnimation)
//         {
//             DefaultLayer.Close(popupBase, skipAnimation);
//         }
//
//         public void CloseAll(bool skipAnimation)
//         {
//             DefaultLayer.CloseAll(skipAnimation);
//         }
//
//         public void CloseAllExcept<TScreen>(bool skipAnimation)
//             where TScreen : TScreenBase
//         {
//             DefaultLayer.CloseAllExcept<TScreen>(skipAnimation);
//         }
//
//         public void CloseAllExcept(bool skipAnimation, params Type[] except)
//         {
//             DefaultLayer.CloseAllExcept(skipAnimation, except);
//         }
//
//         //TODO скорее всего отдельно слои для попапов/панеолей
//         // public bool IsOpened<TScreen>(out TScreen popup)
//         //     where TScreen : TScreenBase
//         // {
//         //     return DefaultLayer.IsOpened(out popup);
//         // }
//         //
//         // public bool IsOpened<TScreen>()
//         //     where TScreen : TScreenBase
//         // {
//         //     return DefaultLayer.IsOpened<TScreen>();
//         // }
//         public IEnumerator<TScreenBase> GetEnumerator()
//         {
//             throw new NotImplementedException();
//         }
//
//         IEnumerator IEnumerable.GetEnumerator()
//         {
//             return GetEnumerator();
//         }
//     }
// }
//
// #endif
