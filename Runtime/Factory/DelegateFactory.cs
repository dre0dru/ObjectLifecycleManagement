using System;

namespace Dre0Dru.Factory
{
    public class DelegateFactory<TResult> : IFactory<TResult>
    {
        private readonly Func<TResult> _createFunc;

        public DelegateFactory(Func<TResult> createFunc)
        {
            _createFunc = createFunc ??
                          throw new ArgumentException(nameof(createFunc));
        }

        public TResult Create() =>
            _createFunc.Invoke();
    }
}