namespace Dre0Dru.Pool
{
    //TODO can be passed to release handle instead of whole pool
    public interface IReleasePool<in TElement>
    {
        void Release(TElement element);
    }

    public interface IGetPool<out TElement>
    {
        TElement Get();
    }

    public interface ICovariantGetPool<in TConstraint>
    {
        TElement Get<TElement>()
            where TElement : class, TConstraint;
    }

    public interface IPoolCommon
    {
        int PooledObjectsCount { get; }

        void Clear();
    }

    //TODO spawner extensions like Spawn.MarkAsPooled
    //TODO DynamicPooledObjectHandle - get any and return object to pool instead of referencing whole pool
    public interface IPool<TElement> : IGetPool<TElement>, IReleasePool<TElement>, IPoolCommon
    {
    }

    public interface ICovariantPool<in TConstraint> : ICovariantGetPool<TConstraint>, IReleasePool<TConstraint>,
        IPoolCommon
    {
    }
}
