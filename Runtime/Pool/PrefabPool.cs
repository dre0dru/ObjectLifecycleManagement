using System;

namespace Dre0Dru.Pool
{
    public class PrefabPool<TPrefab> : IPool<TPrefab>
        where TPrefab : class
    {
        private readonly TPrefab _prefab;
        private readonly IPool<TPrefab> _pool;
        private readonly Func<TPrefab, TPrefab> _createFunc;

        public int PooledObjectsCount => _pool.PooledObjectsCount;

        public PrefabPool(
            TPrefab prefab,
            Func<TPrefab, TPrefab> createFunc,
            Action<TPrefab> onGetAction = null,
            Action<TPrefab> onReleaseAction = null,
            Action<TPrefab> destroyAction = null,
            bool collectionCheck = true,
            int defaultCapacity = 10,
            int maxPoolSize = 10000)
        {
            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab));
            }

            _prefab = prefab;
            _createFunc = createFunc ?? throw new ArgumentNullException(nameof(createFunc));
            _pool = new DelegatePool<TPrefab>(Create, onGetAction, onReleaseAction, destroyAction,
                collectionCheck, defaultCapacity, maxPoolSize);
        }

        public TPrefab Get() =>
            _pool.Get();

        public void Release(TPrefab element) =>
            _pool.Release(element);

        public void Clear() =>
            _pool.Clear();

        private TPrefab Create() =>
            _createFunc.Invoke(_prefab);
    }
}
