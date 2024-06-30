namespace Dre0Dru.Screens.UGUI.Popups
{
    public static class PopupsExtensions
    {
        public static TPopup Open<TPopupBase, TPopup>(this IPopupsServicev2<TPopupBase> popupsService, bool skipAnimation = false)
            where TPopupBase : IPopup<TPopupBase>
            where TPopup : TPopupBase
        {
            var popup = popupsService.Instantiate<TPopup>();
            popupsService.Open(popup, skipAnimation);
            return popup;
        }
    }
}
