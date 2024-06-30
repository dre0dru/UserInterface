using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    public class PopupCloseHandle<TPopupBase> : ICloseHandle<TPopupBase>
        where TPopupBase : Component, IPopup<TPopupBase>
    {
        private readonly IPopupsServicev2<TPopupBase> _popupsService;

        public PopupCloseHandle(IPopupsServicev2<TPopupBase> popupsService)
        {
            _popupsService = popupsService;
        }

        public void Close(TPopupBase popup, bool skipAnimation = false)
        {
            _popupsService.Close(popup, skipAnimation);
        }
    }
}
