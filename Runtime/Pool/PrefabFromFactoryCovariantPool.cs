using System;
using System.Collections.Generic;
using Dre0Dru.Collections;
using Dre0Dru.Factory;

namespace Dre0Dru.Pool
{
    public class PrefabFromFactoryCovariantPool<TConstraint> : ICovariantPool<TConstraint>
        where TConstraint : class
    {
        private readonly ICovariantFactory<TConstraint> _covariantFactory;
        private readonly Dictionary<Type, List<TConstraint>> _pool;

        private readonly Action<TConstraint> _onGetAction;
        private readonly Action<TConstraint> _onReleaseAction;
        private readonly Action<TConstraint> _destroyAction;

        public int PooledObjectsCount
        {
            get
            {
                var count = 0;
                foreach (var list in _pool.Values)
                {
                    count += list.Count;
                }

                return count;
            }
        }

        public TElement Get<TElement>()
            where TElement : class, TConstraint
        {
            var list = _pool.GetOrCreateList<TConstraint, TElement>();

            var element = GetOrCreateElement<TElement>(list);

            _onGetAction?.Invoke(element);

            return element;
        }

        public void Release(TConstraint element)
        {
            _onReleaseAction?.Invoke(element);

            var list = _pool.GetOrCreateList(element.GetType());

            list.Add(element);
        }

        public void Clear()
        {
            foreach (var list in _pool.Values)
            {
                foreach (var element in list)
                {
                    _destroyAction?.Invoke(element);
                }
            }

            _pool.Clear();
        }

        private TElement GetOrCreateElement<TElement>(IList<TConstraint> list)
            where TElement : class, TConstraint
        {
            if (list.TryPopLast(out var constrainedElement))
            {
                return constrainedElement as TElement;
            }

            var element = _covariantFactory.Create<TElement>();
            list.Add(element);

            return element;
        }
    }
}
