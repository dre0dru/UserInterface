using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Popups
{
    //TODO попробовать сделать общую реализацию чисто на основе Iscreen и Iscreen serice
    public class PopupCloseHandle<TPopupBase> : ICloseHandle<TPopupBase>
        where TPopupBase : Component, IPopup<TPopupBase>
    {
        private readonly IPopupsService<TPopupBase> _popupsService;

        public PopupCloseHandle(IPopupsService<TPopupBase> popupsService)
        {
            _popupsService = popupsService;
        }

        public void Close(TPopupBase popup, bool skipAnimation = false)
        {
            _popupsService.Close(popup, skipAnimation);
        }
    }
}
