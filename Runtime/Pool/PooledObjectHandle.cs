using System;

namespace Dre0Dru.Pool
{
    //TODO PooledObjectReleaseHandle? PoolHandle? ReleaseHandle?
    //TODO может без лишнего в плане Value и т.д.?
    //TODo !!! еще как вариант сделать чисто пул хендл, который можно создавать по запросу
    //или просто передавать в OnGet. Это будет чисто struct handle на сам пул
    //и сделать экстеншн методы, которые по интерфейсу (если пулед объект наследуется)
    //внутрь прокидывать хендл на сам пул, то есть все сетапить полуавтоматом
    //но тогда это накладывает ограничение, что объект прям обязон должен заимплементить интерфейс
    //не получится сделать отдельный компонент, так как в таком случае отдельный будет имплментором
    //а это возвращение к текущей логике
    //TODO использовать, когда объект не наследует интерфейс и хотим пометить как poolable
    public readonly struct PooledObjectHandle<TElement> : IDisposable 
        where TElement : class
    {
        private readonly TElement _element;
        private readonly IReleasePool<TElement> _pool;

        public PooledObjectHandle(TElement element, IReleasePool<TElement> pool)
        {
            _element = element;
            _pool = pool;
        }

        public void Dispose() => _pool.Release(_element);

        public static implicit operator TElement(PooledObjectHandle<TElement> handle) =>
            handle._element;
    }
}
