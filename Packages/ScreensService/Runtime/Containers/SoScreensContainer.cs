using System.Collections.Generic;
using UnityEngine;

namespace ScreensService.Containers
{
    [CreateAssetMenu(fileName = "SoScreensContainer", menuName = "MENUNAME", order = 0)]
    public class SoScreensContainer<TScreenConstraint, TScreenKey> : ScriptableObject,
        IScreensContainer<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        [SerializeField]
        private SoScreenKey<TScreenConstraint, TScreenKey>[] _screens;
        
        private Dictionary<TScreenKey, TScreenConstraint> _instantiatedScreens;

        public TScreen GetOrCreateScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            if (_instantiatedScreens.TryGetValue(screenKey, out var screen))
            {
                return screen
            }
        }

        public TScreenConstraint GetOrCreateScreen(TScreenKey screenKey)
        {
            
        }

        public void DisposeScreen(TScreenConstraint screen, TScreenKey screenKey)
        {
            
        }

        public void Dispose()
        {
            foreach (var screen in _instantiatedScreens.Values)
            {
                Object.Destroy(screen.gameObject);
            }

            _instantiatedScreens.Clear();
        }

        private TScreenConstraint GetScreenByKey(TScreenKey screenKey)
        {
            
        }
    }
}