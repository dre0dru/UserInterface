﻿using System;

namespace Dre0Dru.UI.Screens
{
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

    public interface ISelfCloseableScreen
    {
        ICloseHandle CloseHandle { set; }

        void Close(bool skipAnimation = false);
    }

    public interface ISelfOpenableScreen
    {
        IOpenHandle OpenHandle { set; }

        void Open(bool skipAnimation = false);
    }
}
