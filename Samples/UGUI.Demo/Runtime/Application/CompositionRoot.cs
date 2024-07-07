using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Domain;
using Dre0Dru.UI.Screens.UGUI.Demo.Panels;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application
{
    //TODO разные презентеры для каунтера - один из них x2
    //разные для панелей и попапов - все открывают попапы на разных слоях
    //плюс показать, что лейеры имплементирую.т обычный и открывают на дефолте
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField]
        private PanelsService _panelsService;

        [SerializeField]
        private PopupsServiceLayers _popupsServiceLayers;

        private readonly Counter _counter = new();
        private IPresentersFactory _presentersFactory;

        private void Start()
        {
            _presentersFactory = new PresentersFactory(_panelsService, _popupsServiceLayers, _counter);

            _panelsService.Get<FirstPanel>().SetPresenter(_presentersFactory.CreateFirstPanelPresenter());
            _panelsService.Get<SecondPanel>().SetPresenter(_presentersFactory.CreateSecondPanelPresenter());
        }
    }
}
