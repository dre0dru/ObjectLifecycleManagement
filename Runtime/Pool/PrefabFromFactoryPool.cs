using System;
using Dre0Dru.Factory;

namespace Dre0Dru.Pool
{
    public class PrefabFromFactoryPool<TPrefab> : IPool<TPrefab>, IFactory<TPrefab>
        where TPrefab : class
    {
        private readonly IFactory<TPrefab> _factory;
        private readonly IPool<TPrefab> _pool;

        public int PooledObjectsCount => _pool.PooledObjectsCount;

        public PrefabFromFactoryPool(IFactory<TPrefab> factory,
            Action<TPrefab> onGetAction = null,
            Action<TPrefab> onReleaseAction = null,
            Action<TPrefab> destroyAction = null,
            bool collectionCheck = true,
            int defaultCapacity = 10,
            int maxPoolSize = 10000)
        {
            _factory = factory;
            _pool = new DelegatePool<TPrefab>(Create, onGetAction, onReleaseAction, destroyAction,
                collectionCheck, defaultCapacity, maxPoolSize);
        }

        public TPrefab Get()
        {
            return _pool.Get();
        }

        public void Release(TPrefab element)
        {
            _pool.Release(element);
        }

        public void Clear()
        {
            _pool.Clear();
        }

        public TPrefab Create() =>
            _factory.Create();
    }
}
