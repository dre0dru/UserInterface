using System;

namespace ScreensService.Containers
{
    [Serializable]
    public struct SoScreenKey<TScreenConstraint, TScreenKey>
    {
        public TScreenConstraint ScreenConstraint;
        public TScreenKey ScreenKey;
    }
}