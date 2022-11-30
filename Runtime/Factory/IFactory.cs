namespace Dre0Dru.Factory
{
    //TODO ComponentFactory that adds component to gameobjects and resolves dependencies 
    public interface IFactory<out TResult>
    {
        TResult Create();
    }
    
    public interface IFactory<in TContext, out TResult>
    {
        TResult Create(TContext context);
    }

    public interface IGenericFactory<in TConstraint>
    {
        TResult Create<TResult>()
            where TResult : TConstraint;
    }
    
    public interface IGenericFactory<in TConstraint, in TContext>
    {
        TResult Create<TResult>(TContext context)
            where TResult : TConstraint;
    }
}
