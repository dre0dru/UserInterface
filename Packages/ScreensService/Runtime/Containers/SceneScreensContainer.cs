using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;

namespace ScreensService.Containers
{
    public class SceneScreensContainer<TScreenConstraint> : IScreensContainer<TScreenConstraint>
        where TScreenConstraint : Component
    {
        private readonly Transform _screensRoot;
        private readonly Dictionary<Type, TScreenConstraint> _rootScreens;

        [RequiredMember]
        public SceneScreensContainer(Transform screensRoot)
        {
            _screensRoot = screensRoot;
            _rootScreens = FillDictionary();
        }

        public TScreen LoadScreen<TScreen>()
            where TScreen : TScreenConstraint
        {
            return GetScreenFromRoot<TScreen>();
        }

        public void UnloadScreen<TScreen>()
            where TScreen : TScreenConstraint
        {
            //TODO screenType в метод, наверное internal extension
            var screenType = typeof(TScreen);
            if (_rootScreens.TryGetValue(screenType, out var screen))
            {
                Object.Destroy(screen.gameObject);
                _rootScreens.Remove(screenType);
            }
        }

        public bool IsScreenLoaded<TScreen>()
            where TScreen : TScreenConstraint
        {
            return _rootScreens.ContainsKey(typeof(TScreen));
        }
        
        public void Dispose()
        {
            foreach (var screen in _rootScreens.Values)
            {
                Object.Destroy(screen.gameObject);
            }
            
            _rootScreens.Clear();
        }

        private Dictionary<Type, TScreenConstraint> FillDictionary()
        {
            return _screensRoot.GetComponentsInChildren<TScreenConstraint>()
                .ToDictionary(screen => screen.GetType());
        }

        private TScreen GetScreenFromRoot<TScreen>()
            where TScreen : TScreenConstraint
        {
            var screenType = typeof(TScreen);
            if (!_rootScreens.TryGetValue(screenType, out var screen))
            {
                screen = _screensRoot.GetComponentInChildren<TScreen>();
                
                if (screen == null)
                {
                    throw new ArgumentException($"No screen of type [{screenType}] found in root [{_screensRoot}]");
                }
                
                _rootScreens.Add(screenType, screen);
            }

            return screen.GetComponent<TScreen>();
        }
    }
}