using System;
using System.Collections.Generic;
using Shared.Sources.Collections;
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
        private UDictionaryMono<TScreenKey, TScreenConstraint> _screenInstances;

        [SerializeField]
        private UDictionarySo<TScreenKey, TScreenConstraint> _screenPrefabs;

        private TScreenKey[] _screenKeys;

        public ICollection<TScreenKey> Keys => _screenKeys;

        private void Awake()
        {
            InitScreenKeys();
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

        private void InitScreenKeys()
        {
            var count = _screenInstances == null ? 0 : _screenInstances.Count;
            count += _screenPrefabs == null ? 0 : _screenPrefabs.Count;
            _screenKeys = new TScreenKey[count];

            var index = 0;
            if (_screenInstances != null)
            {
                _screenInstances.Keys.CopyTo(_screenKeys, 0);
                index += _screenInstances.Count;
            }

            if (_screenPrefabs != null)
            {
                _screenPrefabs.Keys.CopyTo(_screenKeys, index);
            }
        }
    }
}
