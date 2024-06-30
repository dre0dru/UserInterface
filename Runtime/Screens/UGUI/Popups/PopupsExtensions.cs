namespace Dre0Dru.Screens.UGUI.Popups
{
    public static class PopupsExtensions
    {
        public static TPopup Open<TPopupBase, TPopup>(this IPopupsService<TPopupBase> popupsService, bool skipAnimation = false)
            where TPopupBase : IScreen
            where TPopup : TPopupBase
        {
            if (!popupsService.TryGet(out TPopup popup))
            {
                popupsService.Instantiate<TPopup>();
                popupsService.Open(popup, skipAnimation);
            }

            return popup;
        }

        public static void Close<TPopupBase, TPopup>(this IPopupsService<TPopupBase> popupsService, bool skipAnimation = false)
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
    }
}
