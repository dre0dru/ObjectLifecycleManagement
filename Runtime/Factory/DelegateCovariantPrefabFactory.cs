using System;
using System.Collections.Generic;
using System.Linq;

namespace Dre0Dru.Factory
{
    public class DelegateCovariantPrefabFactory<TConstraint> : ICovariantFactory<TConstraint>
        where TConstraint : class
    {
        private readonly Dictionary<Type, TConstraint> _prefabs;
        private readonly Func<TConstraint, TConstraint> _createFunc;

        public DelegateCovariantPrefabFactory(IEnumerable<TConstraint> prefabs, 
            Func<TConstraint, TConstraint> createFunc)
        {
            _prefabs = prefabs.ToDictionary(constraint => constraint.GetType());
            _createFunc = createFunc;
        }

        public TResult Create<TResult>() 
            where TResult : TConstraint
        {
            var constrained = _prefabs[typeof(TResult)];

            var result = _createFunc.Invoke(constrained);

            return (TResult)result;
        }
    }
}
