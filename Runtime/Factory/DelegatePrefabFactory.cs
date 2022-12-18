using System;

namespace Dre0Dru.Factory
{
    public class DelegatePrefabFactory<TResult> : IFactory<TResult>
        where TResult : class
    {
        private readonly TResult _prefab;
        private readonly Func<TResult, TResult> _createFunc;

        public DelegatePrefabFactory(TResult prefab, Func<TResult, TResult> createFunc)
        {
            _prefab = prefab;
            _createFunc = createFunc;
        }

        public TResult Create() =>
            _createFunc.Invoke(_prefab);
    }
}
