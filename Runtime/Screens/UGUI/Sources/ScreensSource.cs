using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    //TODO попробовать тоже через интерфейс?
    //то есть в самом сервисе указывать что за source как генерик
    //с констрейнтом по интерфейсу
    //TODO плюс доп интерфейсы констрейнты типо IPooledScreenSource
    public abstract class ScreensSource<TScreenBase> : MonoBehaviour, IEnumerable<TScreenBase>
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
