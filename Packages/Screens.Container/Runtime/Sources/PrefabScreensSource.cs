using System.Collections.Generic;
using UnityEngine;

namespace Screens.Container.Sources
{
    public class PrefabScreensSource<TScreenKey, TScreenConstraint> : ScriptableObject,
        IScreensSource<TScreenKey, TScreenConstraint>
        where TScreenConstraint : Component
    {
        [SerializeField]
        protected List<KeyToScreen<TScreenKey, TScreenConstraint>> _screens;

        public bool IsInstanced => false;

        public IEnumerable<KeyToScreen<TScreenKey, TScreenConstraint>> Screens => _screens;
    }
}
