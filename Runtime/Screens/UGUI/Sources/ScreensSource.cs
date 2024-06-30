using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Sources
{
    public abstract class ScreensSource<TScreenBase> : MonoBehaviour, IScreensSource<TScreenBase>
        where TScreenBase : IScreen
    {
        public abstract TScreen Get<TScreen>()
            where TScreen : TScreenBase;

        public abstract IEnumerator<TScreenBase> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
