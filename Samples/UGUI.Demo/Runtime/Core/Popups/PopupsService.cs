using Dre0Dru.UI.Screens.UGUI.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface IPooledPopupsService<TPopupBase> : IPopupsService<TPopupBase>
        where TPopupBase : IScreen, IPooledScreen, ISelfCloseableScreen
    {

    }

    public interface IPopupsService : IPooledPopupsService<PopupBase>
    {

    }

    public class PopupsService : PopupsService<PopupBase, PopupsPooledSource>, IPopupsService
    {
        public override TPopup Create<TPopup>()
        {
            var popup = base.Create<TPopup>();

            popup.CloseHandle = new ScreenOpenCloseHandle<PopupBase>(popup, this);

            return popup;
        }
    }
}
