﻿namespace Dre0Dru.Factory
{
    public interface IIocFactory
    {
        public TResult Create<TResult, T>(T param);
        public TResult Create<TResult, T1, T2>(T1 param1, T2 param2);
        public TResult Create<TResult, T1, T2, T3>(T1 param1, T2 param2, T3 param3);
        public TResult Create<TResult>(params object[] parameters);

        public TResult Inject<TResult>(TResult injected);
    }
}
