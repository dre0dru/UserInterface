using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Pool;

namespace Dre0Dru.Screens
{
    public static class ScreensExtensions
    {
        //TODO асинк WaitForOpen/Close/Started/Finished
        //то есть можно начать заранее и просто ждать коллбека от системы

        public static bool IsOpenedOrOpening(this IScreen screen)
        {
            return screen.State == ScreenState.Opening || screen.State == ScreenState.Opened;
        }

        public static bool IsClosedOrClosing(this IScreen screen)
        {
            return screen.State == ScreenState.Closing || screen.State == ScreenState.Closed;
        }

        public static void CloseAll<TScreenBase>(IScreensService<TScreenBase> screensService,
            bool skipAnimation = false)
            where TScreenBase : IScreen
        {
            using var _ = CollectionPool<List<TScreenBase>, TScreenBase>.Get(out var list);

            list.AddRange(screensService);

            foreach (var screen in list)
            {
                screensService.Close(screen, skipAnimation);
            }
        }

        public static void CloseAllExcept<TScreenBase, TScreen>(IScreensService<TScreenBase> screensService,
            bool skipAnimation = false)
            where TScreenBase : IScreen
            where TScreen : TScreenBase
        {
            using var _ = CollectionPool<List<TScreenBase>, TScreenBase>.Get(out var list);

            list.AddRange(screensService);

            foreach (var screen in list)
            {
                if (screen.GetType() == typeof(TScreen))
                {
                    continue;
                }

                screensService.Close(screen, skipAnimation);
            }
        }

        public static void CloseAllExcept<TScreenBase>(IScreensService<TScreenBase> screensService,
            bool skipAnimation = false, params Type[] except)
            where TScreenBase : IScreen
        {
            using var _ = CollectionPool<List<TScreenBase>, TScreenBase>.Get(out var list);

            list.AddRange(screensService);

            foreach (var screen in list)
            {
                if (except.Contains(screen.GetType()))
                {
                    continue;
                }

                screensService.Close(screen, skipAnimation);
            }
        }
    }
}
