using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScreensService.Containers
{
    public class SceneScreensContainer<TScreenConstraint, TScreenKey> : MonoBehaviour,
        IScreensContainer<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        [SerializeField]
        private Transform _screensRoot;

        private Dictionary<TScreenKey, TScreenConstraint> _rootScreens;

        private void Awake()
        {
            _rootScreens = FillDictionary();
        }

        public TScreen GetOrCreateScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            return GetScreenFromRoot<TScreen>(screenKey);
        }

        public TScreenConstraint GetOrCreateScreen(TScreenKey screenKey)
        {
            return GetScreenFromRoot(screenKey);
        }

        public void DisposeScreen(TScreenConstraint screen, TScreenKey screenKey)
        {
            return;
        }

        public void Dispose()
        {
            foreach (var screen in _rootScreens.Values)
            {
                Object.Destroy(screen.gameObject);
            }

            _rootScreens.Clear();
        }

        private Dictionary<TScreenKey, TScreenConstraint> FillDictionary()
        {
            return _screensRoot.GetComponentsInChildren<TScreenConstraint>()
                .ToDictionary(screen => screen.GetComponent<SceneScreenKey<TScreenKey>>().ScreenKey);
        }

        private TScreenConstraint GetScreenFromRoot(TScreenKey screenKey)
        {
            if (!_rootScreens.TryGetValue(screenKey, out var screen))
            {
                var key = _screensRoot.GetComponentInChildren<SceneScreenKey<TScreenKey>>();
                if (key == null)
                {
                    throw new ArgumentException($"No key [{screenKey}] found in root [{_screensRoot}]");
                }

                if (!key.TryGetComponent<TScreenConstraint>(out screen))
                {
                    throw new ArgumentException(
                        $"No screen associated with key [{key.ScreenKey}] found in root [{_screensRoot}]");
                }

                _rootScreens.Add(key.ScreenKey, screen);
            }

            return screen;
        }

        private TScreen GetScreenFromRoot<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            var screen = GetScreenFromRoot(screenKey);

            if (!screen.TryGetComponent<TScreen>(out var screenTyped))
            {
                throw new ArgumentException(
                    $"Invalid type [{typeof(TScreen)}] for key [{screenKey}] in root [{_screensRoot}]");
            }

            return screenTyped;
        }
    }
}