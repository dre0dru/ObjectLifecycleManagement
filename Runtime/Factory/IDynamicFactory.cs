namespace Dre0Dru.Factory
{
    public interface IDynamicFactory
    {
        TResult Create<TResult>();
        TResult Create<TResult, T>(T param);
        TResult Create<TResult, T1, T2>(T1 param1, T2 param2);
        TResult Create<TResult, T1, T2, T3>(T1 param1, T2 param2, T3 param3);
        TResult Create<TResult>(params object[] parameters);
    }
}
