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
            var layer = _popupsServiceLayers.Get(ScreenLayers.Foreground);

            var popup = layer.Create<SecondPopup>()
                .SetPresenter<SecondPopup, ISecondPopupPresenter>(_presentersFactory.CreateSecondPopupPresenter())
                .SetPresenter<SecondPopup, ICounterViewPresenter>(_presentersFactory.CreateCounterViewPresenter());

            layer.Open(popup);
        }

        public void OpenThirdPopup()
        {
            _popupsServiceLayers.OpenWithPresenter<ThirdPopup, ICounterViewPresenter>(_presentersFactory
                .CreateCounterViewMultiplierPresenter());
        }

        void IDisposable.Dispose()
        {
        }
    }
}
