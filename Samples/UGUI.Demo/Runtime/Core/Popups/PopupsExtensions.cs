using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public static class PopupsExtensions
    {
        public static TPopup OpenWithPresenter<TPopup, TPresenter>(this IPopupsServiceLayers popupsServiceLayers,
            TPresenter presenter)
            where TPopup : PopupBase, IPresentable<TPresenter>
            where TPresenter : IPresenter
        {
            return popupsServiceLayers.OpenWithPresenter<PopupBase, TPopup, TPresenter>(presenter);
        }

        public static TPopup OpenWithPresenter<TPopup, TPresenter>(this IPopupsService popupsService,
            TPresenter presenter)
            where TPopup : PopupBase, IPresentable<TPresenter>
            where TPresenter : IPresenter
        {
            return popupsService.OpenWithPresenter<PopupBase, TPopup, TPresenter>(presenter);
        }
    }
}
