using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Sources.ScriptableDatabase;
using UnityEngine;

namespace Screens.Container
{
    public class SceneScreensContainer<TScreenKey, TScreenConstraint> : MonoBehaviour,
        IScreensContainer<TScreenKey, TScreenConstraint>
        where TScreenConstraint : Component
    {
        [SerializeField]
        private Transform _root;

        [SerializeField]
        private MonoDatabase<TScreenKey, TScreenConstraint>[] _instanceScreensSources;

        [SerializeField]
        private ScriptableDatabase<TScreenKey, TScreenConstraint>[] _prefabScreensSources;

        private Dictionary<TScreenKey, TScreenConstraint> _screenInstances;
        private Dictionary<TScreenKey, TScreenConstraint> _screenPrefabs;

        public IEnumerable<TScreenKey> Keys => _screenInstances.Keys.Concat(_screenPrefabs.Keys);

        private void Awake()
        {
            _screenInstances = new Dictionary<TScreenKey, TScreenConstraint>();
            FillScreenDictionaries(_instanceScreensSources, _screenInstances);

            _screenPrefabs = new Dictionary<TScreenKey, TScreenConstraint>();
            FillScreenDictionaries(_prefabScreensSources, _screenPrefabs);
        }

        public TScreenConstraint Instantiate(TScreenKey screenKey)
        {
            if (TryInstantiateFromPrefabSources(screenKey, out var instance) == false)
            {
                Debug.LogWarning($"No prefab found for key [{screenKey}], instantiating from instance");

                instance = InstantiateFromPrefabInstances(screenKey);
            }

            return instance;
        }

        public TScreen Instantiate<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            var instance = Instantiate(screenKey);

            return GetTypedInstance<TScreen>(instance);
        }

        public TScreenConstraint GetInstance(TScreenKey screenKey)
        {
            if (TryGetScreenInstance(screenKey, out var instance) == false)
            {
                instance = Instantiate(screenKey);
            }

            return instance;
        }

        public TScreen GetInstance<TScreen>(TScreenKey screenKey)
            where TScreen : TScreenConstraint
        {
            var instance = GetInstance(screenKey);

            return GetTypedInstance<TScreen>(instance);
        }

        private bool TryInstantiateFromPrefabSources(TScreenKey screenKey, out TScreenConstraint instance)
        {
            instance = default;

            if (_screenPrefabs.TryGetValue(screenKey, out var prefab))
            {
                instance = InstantiateScreen(prefab);

                if (_screenInstances.ContainsKey(screenKey) == false)
                {
                    _screenInstances.Add(screenKey, instance);
                }

                return true;
            }

            return false;
        }

        private TScreenConstraint InstantiateFromPrefabInstances(TScreenKey screenKey)
        {
            if (TryGetScreenInstance(screenKey, out var instance) == false)
            {
                throw new ArgumentException($"No screen instance found for [{screenKey}]");
            }
            
            return InstantiateScreen(instance);
        }

        private TScreenConstraint InstantiateScreen(TScreenConstraint prefab) =>
            Instantiate<TScreenConstraint>(prefab, _root);

        private bool TryGetScreenInstance(TScreenKey screenKey, out TScreenConstraint instance) =>
            _screenInstances.TryGetValue(screenKey, out instance);

        private TScreen GetTypedInstance<TScreen>(TScreenConstraint instance)
            where TScreen : TScreenConstraint
        {
            if (instance.TryGetComponent<TScreen>(out var screen) == false)
            {
                throw new ArgumentException(
                    $"Invalid type [{typeof(TScreen)}]");
            }

            return screen;
        }

        private void FillScreenDictionaries(IScriptableDatabase<TScreenKey, TScreenConstraint>[] screensSources,
            Dictionary<TScreenKey, TScreenConstraint> collection)
        {
            foreach (var source in screensSources)
            {
                foreach (var screenKey in source.Keys)
                {
                    if (collection.ContainsKey(screenKey))
                    {
                        Debug.LogError($"Trying to add duplicate key [{screenKey}]");
                        continue;
                    }

                    collection[screenKey] = source.Get(screenKey);
                }
            }
        }
    }
}
