using System;

namespace ScreensService
{
    [Serializable]
    public struct KeyToScreen<TScreenKey, TScreenConstraint>
    {
        public TScreenKey Key;
        public TScreenConstraint Screen;
    }
}