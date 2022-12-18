using System;

namespace Dre0Dru.DestroyStrategy
{
    public class DelegateDestroyStrategy : IDestroyStrategy
    {
        private readonly Action _destroyAction;

        public DelegateDestroyStrategy(Action destroyAction)
        {
            _destroyAction = destroyAction;
        }

        public void Destroy() => 
            _destroyAction?.Invoke();
    }
    
    public class DelegateDestroyStrategy<T> : IDestroyStrategy
    {
        private readonly Action<T> _destroyAction;
        private readonly T _obj;

        public DelegateDestroyStrategy(T obj, Action<T> destroyAction)
        {
            _obj = obj;
            _destroyAction = destroyAction;
        }

        public void Destroy() => 
            _destroyAction?.Invoke(_obj);
    }
}
