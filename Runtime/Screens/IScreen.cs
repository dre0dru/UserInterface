using System;

namespace Dre0Dru.Screens
{
    public interface IScreen
    {
        event Action<ScreenState> StateChanged;

        ScreenState State { get; }

        void Open(Action onComplete);
        void OpenAnimated(Action onComplete);

        void Close(Action onComplete);
        void CloseAnimated(Action onComplete);
    }

    public interface IPooledScreen
    {
        bool IsPooled { get; }

        void OnReturnToPool();
    }
}
