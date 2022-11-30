namespace Dre0Dru.Pool
{
    //TODO использовать, когда объект наследует нужный интефрфейс
    public readonly struct PoolReleaseHandle<TElement>
    {
        private readonly IPool<TElement> _pool;

        public PoolReleaseHandle(IPool<TElement> pool)
        {
            _pool = pool;
        }

        public void Release(TElement element)
        {
            _pool.Release(element);
        }
    }
}