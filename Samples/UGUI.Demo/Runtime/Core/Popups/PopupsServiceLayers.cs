using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface IPopupsServiceLayers : IScreensServiceLayers<PopupsService, ScreenLayers, PopupBase>
    {

    }

    public class PopupsServiceLayers : PopupsServiceLayers<PopupsService, ScreenLayers, PopupBase>, IPopupsServiceLayers
    {
        
    }
}
