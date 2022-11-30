using System;
using UnityEngine.Pool;

namespace Dre0Dru.Pool
{
    public class DelegatePool<TElement> : IPool<TElement>
        where TElement : class
    {
        private readonly IObjectPool<TElement> _pool;
        private readonly Func<TElement> _createFunc;

        public int PooledObjectsCount => _pool.CountInactive;

        public DelegatePool(
            Func<TElement> createFunc,
            Action<TElement> onGetAction = null,
            Action<TElement> onReleaseAction = null,
            Action<TElement> destroyAction = null,
            bool collectionCheck = true,
            int defaultCapacity = 10,
            int maxPoolSize = 10000)
        {
            _createFunc = createFunc ??
                          throw new ArgumentNullException(nameof(createFunc));
            _pool = new ObjectPool<TElement>(Create, onGetAction, onReleaseAction, destroyAction,
                collectionCheck, defaultCapacity, maxPoolSize);
        }

        public void Prewarm(int count)
        {
            for (var i = 0; i < count; i++)
            {
                Release(Create());
            }
        }

        public TElement Get() =>
            _pool.Get();

        public void Release(TElement element) =>
            _pool.Release(element);

        public void Clear() =>
            _pool.Clear();

        private TElement Create() =>
            _createFunc.Invoke();
    }
}