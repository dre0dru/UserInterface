using Dre0Dru.Screens.UGUI.Popups;

namespace Dre0Dru.Screens.UGUI
{
    public static class ScreensExtensions
    {
        public static bool IsOpenedOrOpening(this ScreenBase screen)
        {
            return screen.State == ScreenState.Opening || screen.State == ScreenState.Opened;
        }

        public static bool IsOpenedOrOpening(this PopupBase screen)
        {
            return screen.State == ScreenState.Opening || screen.State == ScreenState.Opened;
        }

        public static bool IsClosedOrClosing(this ScreenBase screen)
        {
            return screen.State == ScreenState.Closing || screen.State == ScreenState.Closed;
        }

        public static void SetSortingOrder(this ScreenBase screen, int order)
        {
            screen.Canvas.overrideSorting = true;
            screen.Canvas.sortingOrder = order;
        }
    }
}
