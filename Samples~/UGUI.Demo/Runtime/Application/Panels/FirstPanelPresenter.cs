using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Panels;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application.Panels
{
    public class FirstPanelPresenter : IFirstPanelPresenter
    {
        private readonly IPanelsService _panelsService;

        public FirstPanelPresenter(IPanelsService panelsService)
        {
            _panelsService = panelsService;
        }

        public void NextPanel()
        {
            _panelsService.Get<FirstPanel>().Close();
            _panelsService.Get<SecondPanel>().Open();
        }

        void IDisposable.Dispose()
        {
        }
    }
}
