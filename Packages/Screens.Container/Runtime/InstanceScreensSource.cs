using System.Collections.Generic;
using UnityEngine;

namespace Screens.Container
{
    public abstract class InstanceScreensSource<TScreenKey, TScreenConstraint> : MonoBehaviour,
        IScreensSource<TScreenKey, TScreenConstraint>
        where TScreenConstraint : Component
    {
        public abstract IEnumerable<TScreenKey> Keys { get; }
        
        public abstract TScreenConstraint Get(TScreenKey screenKey);
    }
}
