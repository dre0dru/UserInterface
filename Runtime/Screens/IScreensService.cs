using System;
using System.Collections.Generic;

namespace Dre0Dru.Screens
{
    public interface IScreensServicev2<TScreenBase> : IEnumerable<TScreenBase>
        where TScreenBase : IScreen
    {
        event Action<TScreenBase, ScreenState> StateChanged;

        void Open(TScreenBase popupBase, bool skipAnimation = false);

        void Close(TScreenBase popupBase, bool skipAnimation = false);
    }

    public interface IPopupsServicev2<TPopupBase> : IScreensServicev2<TPopupBase>
        where TPopupBase : IPopup<TPopupBase>
    {
        int OpenedPopupsCount { get; }

        TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase;

        bool TryGet<TPopup>(out TPopup popup)
            where TPopup : TPopupBase;
    }


    public interface IScreensService<TScreenBase> : IEnumerable<TScreenBase>
    {
        //TODO может при создании (или при наличии в панелях) подписываться на локальные
        //эвенты и форвардить?
        //TODO и тогда можно работать как через сервис, так и через сам попап
        //и сделать методы Get(для всех)/TryGet(для попапов)
        event Action<TScreenBase> OpenStarted;
        event Action<TScreenBase> OpenFinished;
        event Action<TScreenBase> CloseStarted;
        event Action<TScreenBase> CloseFinished;

        TScreen Open<TScreen>(bool skipAnimation)
            where TScreen : TScreenBase;

        void Open(TScreenBase popupBase, bool skipAnimation);

        void Close<TScreen>(bool skipAnimation)
            where TScreen : TScreenBase;

        void Close(TScreenBase popupBase, bool skipAnimation);

        void CloseAll(bool skipAnimation);

        void CloseAllExcept<TScreen>(bool skipAnimation)
            where TScreen : TScreenBase;

        void CloseAllExcept(bool skipAnimation, params Type[] except);
    }

    //TODO может тоже избавиться от open close и как-то по-другому работать с попапами?
    //то есть чисто спавн на нужных слоях и все
    public interface IPopupsService<TPopupBase> : IScreensService<TPopupBase>
    {
        event Action<int> OpenedCountChanged;

        int OpenedPopupsCount { get; }

        //TODO может этот апи будет чисто спавнить в пуле?
        //то есть disabled состояние по сути
        //TODO заблочить OnEnable/Disable, сделать свой OnCreate
        //в дополнение к Open/Close Started/Finished
        TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase;

        bool IsOpened<TPopup>(out TPopup popup)
            where TPopup : TPopupBase;

        bool IsOpened<TScreen>()
            where TScreen : TPopupBase;
    }

    //TODO убрать Open/Close API, сделать в самой панели Opne/Close публичными?
    public interface IPanelsService<TPanelBase> : IScreensService<TPanelBase>
    {
        TPanel Get<TPanel>()
            where TPanel : TPanelBase;
    }
}
