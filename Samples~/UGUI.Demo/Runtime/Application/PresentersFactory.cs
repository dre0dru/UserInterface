using Dre0Dru.UI.Screens.UGUI.Demo.Application.Panels;
using Dre0Dru.UI.Screens.UGUI.Demo.Application.Popups;
using Dre0Dru.UI.Screens.UGUI.Demo.Domain;
using Dre0Dru.UI.Screens.UGUI.Demo.Panels;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application
{
    public interface IPresentersFactory
    {
        IFirstPanelPresenter CreateFirstPanelPresenter();
        ISecondPanelPresenter CreateSecondPanelPresenter();
        IFirstPopupPresenter CreateFirstPopupPresenter();
        IThirdPopupPresenter CreateThirdPopupPresenter();
        ISecondPopupPresenter CreateSecondPopupPresenter();
        ICounterViewPresenter CreateCounterViewPresenter();
        ICounterViewPresenter CreateCounterViewMultiplierPresenter();
    }

    public class PresentersFactory : IPresentersFactory
    {
        private readonly IPanelsService _panelsService;
        private readonly IPopupsServiceLayers _popupsServiceLayers;
        private readonly Counter _counter;

        public PresentersFactory(IPanelsService panelsService, IPopupsServiceLayers popupsServiceLayers, Counter counter)
        {
            _counter = counter;
            _popupsServiceLayers = popupsServiceLayers;
            _panelsService = panelsService;
        }

        public IFirstPanelPresenter CreateFirstPanelPresenter()
        {
            return new FirstPanelPresenter(_panelsService);
        }

        public ISecondPanelPresenter CreateSecondPanelPresenter()
        {
            return new SecondPanelPresenter(_panelsService, _popupsServiceLayers, this);
        }

        public IFirstPopupPresenter CreateFirstPopupPresenter()
        {
            return new FirstPopupPresenter(_popupsServiceLayers, this);
        }

        public ISecondPopupPresenter CreateSecondPopupPresenter()
        {
            return new SecondPopupPresenter(_popupsServiceLayers, this);
        }

        public IThirdPopupPresenter CreateThirdPopupPresenter()
        {
            return new ThirdPopupPresenter();
        }

        public ICounterViewPresenter CreateCounterViewPresenter()
        {
            return new CounterViewPresenter(_counter);
        }

        public ICounterViewPresenter CreateCounterViewMultiplierPresenter()
        {
            return new CounterViewMultiplierPresenter(_counter, 4);
        }
    }
}
