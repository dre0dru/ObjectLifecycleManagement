namespace Dre0Dru.Pool
{
    //TODO spawner extensions like Spawn.MarkAsPooled
    //TODO DynamicPooledObjectHandle - get any and return gotten object to pool instead of referencing whole pool
    public interface IPool<TElement>
    {
        int PooledObjectsCount { get; }

        void Prewarm(int count);

        TElement Get();

        void Release(TElement element);

        void Clear();
    }
}