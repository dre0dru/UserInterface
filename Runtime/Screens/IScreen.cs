using System;

namespace Dre0Dru.Screens
{
    //TODO сделать asmdef и неймспейс как Dre0Dru.UI.Screens
    public interface IScreen
    {
        event Action<ScreenState> StateChanged;

        ScreenState State { get; }

        void Open(Action onComplete, bool skipAnimation = false);

        void Close(Action onComplete, bool skipAnimation = false);
    }

    public interface IPooledScreen
    {
        bool IsPooled { get; }

        void ResetOnReturnToPool();
    }

    public interface ISelfCloseableScreen<out TScreenBase>
    {
        ICloseHandle<TScreenBase> CloseHandle { set; }

        void Close(bool skipAnimation = false);
    }

    public interface IPopup<out TPopupBase> : IScreen, IPooledScreen, ISelfCloseableScreen<TPopupBase>
        where TPopupBase : IPopup<TPopupBase>
    {
    }
}
