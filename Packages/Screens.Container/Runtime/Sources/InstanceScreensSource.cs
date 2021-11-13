using System.Collections.Generic;
using UnityEngine;

namespace Screens.Container.Sources
{
    public class InstanceScreensSource<TScreenKey, TScreenConstraint> : MonoBehaviour,
        IScreensSource<TScreenKey, TScreenConstraint>
        where TScreenConstraint : Component
    {
        [SerializeField]
        protected List<KeyToScreen<TScreenKey, TScreenConstraint>> _screens;

        public bool IsInstanced => true;

        public IEnumerable<KeyToScreen<TScreenKey, TScreenConstraint>> Screens => _screens;
    }
}
