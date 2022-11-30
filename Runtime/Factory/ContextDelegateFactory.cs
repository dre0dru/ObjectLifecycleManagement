using System;

namespace Dre0Dru.Factory
{
    public class ContextDelegateFactory<TContext, TResult> : IFactory<TContext, TResult>
    {
        private readonly Func<TContext, TResult> _createFunc;

        public ContextDelegateFactory(Func<TContext, TResult> createFunc)
        {
            _createFunc = createFunc ??
                          throw new ArgumentException(nameof(createFunc));
        }

        public TResult Create(TContext context) =>
            _createFunc.Invoke(context);
    }
}