using System;
using UnityEngine;

namespace ScreensService
{
    public interface IScreensContainer<in TScreenConstraint> : IDisposable
        where TScreenConstraint : Component
    {
        TScreen LoadScreen<TScreen>()
            where TScreen : TScreenConstraint;
        
        void UnloadScreen<TScreen>()
            where TScreen : TScreenConstraint;

        bool IsScreenLoaded<TScreen>()
            where TScreen : TScreenConstraint;
    }
}