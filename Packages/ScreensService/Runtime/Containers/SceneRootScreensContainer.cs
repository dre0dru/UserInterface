using System.Collections.Generic;
using UnityEngine;

namespace ScreensService.Containers
{
    public class SceneRootScreensContainer<TScreenConstraint, TScreenKey> : MonoBehaviour,
        IScreensContainer<TScreenConstraint, TScreenKey>
        where TScreenConstraint : Component
    {
        [SerializeField]
        private SceneScreensContainer<TScreenConstraint, TScreenKey>[] _sceneScreensContainers;

        private Dictionary<TScreenKey, SceneScreensContainer<TScreenConstraint, TScreenKey>>
            _sceneScreensContainersByKey;

        private HashSet<TScreenKey> _keys;

        public IEnumerable<TScreenKey> Keys => _keys;

        private void Awake()
        {
            _sceneScreensContainersByKey =
                new Dictionary<TScreenKey, SceneScreensContainer<TScreenConstraint, TScreenKey>>();
            _keys = new HashSet<TScreenKey>();
            foreach (var container in _sceneScreensContainers)
            {
                foreach (var screenKey in container.Keys)
                {
                    _sceneScreensContainersByKey.Add(screenKey, container);
                    _keys.Add(screenKey);
                }
            }
        }

        public TScreen GetOrCreateScreen<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            return _sceneScreensContainersByKey[screenKey].GetOrCreateScreen<TScreen>(screenKey);
        }

        public TScreenConstraint GetOrCreateScreen(TScreenKey screenKey)
        {
            return _sceneScreensContainersByKey[screenKey].GetOrCreateScreen(screenKey);
        }
    }
}