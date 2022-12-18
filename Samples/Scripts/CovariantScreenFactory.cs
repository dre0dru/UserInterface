using System.Collections.Generic;
using Dre0Dru.Factory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dre0Dru.Screens
{
    public class CovariantScreenFactory<TScreenBase> : ICovariantFactory<TScreenBase>
        where TScreenBase : MonoBehaviour
    {
        private readonly ICovariantFactory<TScreenBase> _factory;

        public CovariantScreenFactory(IEnumerable<TScreenBase> prefabs)
        {
            _factory = new DelegateCovariantPrefabFactory<TScreenBase>(prefabs, Object.Instantiate);
        }

        public TResult Create<TResult>() where TResult : TScreenBase => 
            _factory.Create<TResult>();
    }
}
