namespace Dre0Dru.UI.Screens.UGUI.Popups
{
    public static class PopupsExtensions
    {
        public static TPopup Open<TPopupBase, TPopup>(this IPopupsService<TPopupBase> popupsService,
            bool skipAnimation = false)
            where TPopupBase : IScreen
            where TPopup : TPopupBase
        {
            if (!popupsService.TryGet(out TPopup popup))
            {
                popup = popupsService.Instantiate<TPopup>();
                popupsService.Open(popup, skipAnimation);
            }

            return popup;
        }

        public static void Close<TPopupBase, TPopup>(this IPopupsService<TPopupBase> popupsService,
            bool skipAnimation = false)
            where TPopupBase : IScreen
            where TPopup : TPopupBase
        {
            if (popupsService.TryGet(out TPopup popup))
            {
                popupsService.Close(popup, skipAnimation);
            }
        }

        public static TPopup Get<TPopupBase, TPopup>(this IPopupsService<TPopupBase> popupsService)
            where TPopupBase : IScreen
            where TPopup : TPopupBase
        {
            popupsService.TryGet(out TPopup popup);
            return popup;
        }

        public static TPopup OpenWithPresenter<TPopupBase, TPopup, TPresenter>(
            this IPopupsService<TPopupBase> popupsService, TPresenter presenter, bool skipAnimation = false)
            where TPopupBase : IScreen
            where TPopup : TPopupBase, IPresentable<TPresenter>
            where TPresenter : IPresenter
        {
            if (!popupsService.TryGet(out TPopup popup))
            {
                popup = popupsService.Instantiate<TPopup>();
                popup.SetPresenter(presenter);
                popupsService.Open(popup, skipAnimation);
            }

            return popup;
        }

        public static TPopup SetPresenter<TPopup, TPresenter>(this TPopup popup, TPresenter presenter)
            where TPopup : IPresentable<TPresenter>
            where TPresenter : IPresenter
        {
            popup.SetPresenter(presenter);
            return popup;
        }
    }
}
