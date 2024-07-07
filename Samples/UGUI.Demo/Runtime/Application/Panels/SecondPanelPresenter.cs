using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Panels;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;
using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application.Panels
{
    public class SecondPanelPresenter : ISecondPanelPresenter
    {
        private readonly IPanelsService _panelsService;
        private readonly IPopupsServiceLayers _popupsServiceLayers;
        private readonly IPresentersFactory _presentersFactory;

        public SecondPanelPresenter(IPanelsService panelsService, IPopupsServiceLayers popupsServiceLayers,
            IPresentersFactory presentersFactory)
        {
            _panelsService = panelsService;
            _popupsServiceLayers = popupsServiceLayers;
            _presentersFactory = presentersFactory;
        }

        public void PreviousPanel()
        {
            _panelsService.Get<SecondPanel>().Close();
            _panelsService.Get<FirstPanel>().Open();
        }

        //Opening on specific layer
        public void OpenFirstPopup()
        {
            _popupsServiceLayers.Get(ScreenLayers.Background)
                .OpenWithPresenter<FirstPopup, IFirstPopupPresenter>(_presentersFactory.CreateFirstPopupPresenter());
        }

        //Not specifying layer, will be opened on default layer (overlay)
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
