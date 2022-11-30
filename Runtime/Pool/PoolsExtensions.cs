using Dre0Dru.ObjectExtensions;
using UnityEngine;

namespace Dre0Dru.Pool
{
    public static class PoolsExtensions
    {
        public static TElement Get<TElement>(this IPool<TElement> pool,
            out PooledObjectHandle<TElement> pooledObjectHandle)
        {
            var element = pool.Get();

            pooledObjectHandle = new PooledObjectHandle<TElement>(element, pool);

            return element;
        }

        public static PoolReleaseHandle<TElement> CreatePoolReleaseHandle<TElement>(this IPool<TElement> pool)
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
            where TElement : IPooledObject<TElement>
        {
            element.SetPool(pool.CreatePoolReleaseHandle());

            return element;
        }
    }
}