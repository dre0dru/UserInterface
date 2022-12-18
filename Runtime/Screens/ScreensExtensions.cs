namespace Dre0Dru.Screens
{
    public static class ScreensExtensions
    {
        public static TScreen PassPayload<TScreen, TPayload>(this TScreen screen, TPayload payload)
            where TScreen : IPayloadedScreen<TPayload>
        {
            screen.SetPayload(payload);
            return screen;
        }
    }
}
