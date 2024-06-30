using System;
using System.Collections.Generic;

namespace Dre0Dru.UI.Screens
{
    public interface IScreensService<TScreenBase> : IEnumerable<TScreenBase>
        where TScreenBase : IScreen
    {
        event Action<TScreenBase, ScreenState> StateChanged;

        void Open(TScreenBase popupBase, bool skipAnimation = false);

        void Close(TScreenBase popupBase, bool skipAnimation = false);
    }

    public interface IPanelsService<TPanel> : IScreensService<TPanel>
        where TPanel : IScreen
    {
        TPopup Get<TPopup>()
            where TPopup : TPanel;
    }

    public interface IPopupsService<TPopupBase> : IScreensService<TPopupBase>
        where TPopupBase : IScreen
    {
        int OpenedPopupsCount { get; }

        TPopup Instantiate<TPopup>()
            where TPopup : TPopupBase;

        bool TryGet<TPopup>(out TPopup popup)
            where TPopup : TPopupBase;
    }
}
