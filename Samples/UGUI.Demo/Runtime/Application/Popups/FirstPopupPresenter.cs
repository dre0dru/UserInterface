using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;
using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application.Popups
{
    public class FirstPopupPresenter : IFirstPopupPresenter
    {
        private readonly IPopupsServiceLayers _popupsServiceLayers;
        private readonly IPresentersFactory _presentersFactory;

        public FirstPopupPresenter(IPopupsServiceLayers popupsServiceLayers, IPresentersFactory presentersFactory)
        {
            _popupsServiceLayers = popupsServiceLayers;
            _presentersFactory = presentersFactory;
        }

        public void OpenSecondPopup()
        {
            var popup = _popupsServiceLayers.Get(ScreenLayers.Foreground).Create<SecondPopup>()
                .SetPresenter<SecondPopup, ISecondPopupPresenter>(_presentersFactory.CreateSecondPopupPresenter())
                .SetPresenter<SecondPopup, ICounterViewPresenter>(_presentersFactory.CreateCounterViewPresenter());

            _popupsServiceLayers.Open(popup);
        }

        public void OpenThirdPopup()
        {
            var popup = _popupsServiceLayers.Create<ThirdPopup>()
                .SetPresenter<ThirdPopup, IThirdPopupPresenter>(_presentersFactory.CreateThirdPopupPresenter())
                .SetPresenter<ThirdPopup, ICounterViewPresenter>(_presentersFactory.CreateCounterViewMultiplierPresenter());

            _popupsServiceLayers.Open(popup);
        }

        void IDisposable.Dispose()
        {
        }
    }
}
