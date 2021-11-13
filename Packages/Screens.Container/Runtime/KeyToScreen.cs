using System;

namespace Screens.Container
{
    [Serializable]
    public struct KeyToScreen<TScreenKey, TScreenConstraint>
    {
        public TScreenKey Key;
        public TScreenConstraint Screen;
    }
}