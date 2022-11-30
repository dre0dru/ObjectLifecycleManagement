namespace Dre0Dru.Pool
{
    public interface IPooledObject
    {
        void Release();
    }

    public interface IPooledObject<TElement> : IPooledObject
    {
        void SetPool(PoolReleaseHandle<TElement> handle);
    }
}