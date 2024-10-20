namespace Dre0Dru.Factory
{
    //TODO ComponentFactory that adds component to gameobjects and resolves dependencies?
    public interface IFactory<out TResult>
    {
        TResult Create();
    }

    public interface ICovariantFactory<in TConstraint>
    {
        TResult Create<TResult>()
            where TResult : TConstraint;
    }
}
