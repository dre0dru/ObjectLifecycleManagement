namespace Dre0Dru.Pool
{
    public interface IPooledObject
    {
        void Release();
    }

    public interface IPooledObject<TElement> : IPooledObject
        where TElement : class
    {
        void SetPool(PoolReleaseHandle<TElement> handle);
    }
}
