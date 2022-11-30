namespace Dre0Dru.Spawner
{
    //TODO for Object - extension methods with chaining
    public interface ISpawner<out TResult>
    {
        TResult Spawn();
    }
    
    public interface ISpawner<in TContext, out TResult>
    {
        TResult Spawn(TContext context);
    }
}
