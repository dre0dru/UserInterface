using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Sources
{
    //TODO попробовать тоже через интерфейс?
    //то есть в самом сервисе указывать что за source как генерик
    //с констрейнтом по интерфейсу
    public abstract class ScreensSource<TScreenBase> : MonoBehaviour
        where TScreenBase : IScreen
    {
        public abstract TScreen Get<TScreen>()
            where TScreen : TScreenBase;
    }
}
