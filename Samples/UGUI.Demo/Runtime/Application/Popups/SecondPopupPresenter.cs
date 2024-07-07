using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;
using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application.Popups
{
    public class SecondPopupPresenter : ISecondPopupPresenter
    {
        private readonly IPopupsServiceLayers _popupsServiceLayers;
        private readonly IPresentersFactory _presentersFactory;

        public SecondPopupPresenter(IPopupsServiceLayers popupsServiceLayers, IPresentersFactory presentersFactory)
        {
            _popupsServiceLayers = popupsServiceLayers;
            _presentersFactory = presentersFactory;
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
