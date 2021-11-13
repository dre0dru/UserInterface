using System;
using System.Collections.Generic;
using UnityEngine;

namespace Screens.Container.Containers
{
    public class InstanceScreensContainer<TScreenKey, TScreenConstraint> : MonoBehaviour,
        IScreensContainer<TScreenKey, TScreenConstraint>
        where TScreenConstraint : Component
    {
        
        [SerializeField]
        protected KeyToScreen<TScreenKey, TScreenConstraint>[] _sceneScreens;

        private Dictionary<TScreenKey, TScreenConstraint> _screens;

        public IEnumerable<TScreenKey> Keys => _screens.Keys;

        private void Awake()
        {
            _screens = new Dictionary<TScreenKey, TScreenConstraint>();
            foreach (var keyToScreen in _sceneScreens)
            {
                _screens.Add(keyToScreen.Key, keyToScreen.Screen);
            }
        }

        public TScreen Get<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            return GetScreen<TScreen>(screenKey);
        }

        public TScreenConstraint Get(TScreenKey screenKey)
        {
            return GetScreenByKey(screenKey);
        }

        private TScreenConstraint GetScreenByKey(TScreenKey screenKey)
        {
            return _screens[screenKey];
        }
        
        private TScreen GetScreen<TScreen>(TScreenKey screenQuery)
            where TScreen : TScreenConstraint
        {
            var screen = GetScreenByKey(screenQuery);

            if (!screen.TryGetComponent<TScreen>(out var screenTyped))
            {
                throw new ArgumentException(
                    $"Invalid type [{typeof(TScreen)}] for query [{screenQuery.ToString()}]]");
            }

            return screenTyped;
        }
    }
}