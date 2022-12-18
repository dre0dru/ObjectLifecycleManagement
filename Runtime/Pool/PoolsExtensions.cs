using Dre0Dru.ObjectExtensions;
using UnityEngine;

namespace Dre0Dru.Pool
{
    public static class PoolsExtensions
    {
        public static TElement Get<TElement>(this IPool<TElement> pool,
            out PooledObjectHandle<TElement> pooledObjectHandle)
            where TElement : class
        {
            var element = pool.Get();

            pooledObjectHandle = new PooledObjectHandle<TElement>(element, pool);

            return element;
        }

        public static PoolReleaseHandle<TElement> CreatePoolReleaseHandle<TElement>(this IPool<TElement> pool)
            where TElement : class
        {
            return new PoolReleaseHandle<TElement>(pool);
        }

        public static TElement MarkAsPooled<TElement, TMarker>(this TElement element, IPool<TElement> pool)
            where TElement : Component
            where TMarker : PooledObjectMarker<TElement>
        {
            element.GetOrAddComponent<TMarker>()
                .Construct(new PooledObjectHandle<TElement>(element, pool));

            return element;
        }

        public static TElement AsPooled<TElement>(this TElement element, IPool<TElement> pool)
            where TElement : class, IPooledObject<TElement>
        {
            element.SetPool(pool.CreatePoolReleaseHandle());

            return element;
        }

        public static void Prewarm<TElement>(this IPool<TElement> pool, int count)
            where TElement : class
        {
            for (var i = 0; i < count; i++)
            {
                pool.Release(pool.Get());
            }
        }
    }
}
