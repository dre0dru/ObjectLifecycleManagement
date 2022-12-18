using UnityEngine;

namespace Dre0Dru.Pool
{
    public class PooledObjectMarker<TComponent> : MonoBehaviour, IPooledObject
        where TComponent : Component
    {
        private PooledObjectHandle<TComponent> _handle;

        //TODO переделать как IDependant<...>
        public void Construct(PooledObjectHandle<TComponent> handle)
        {
            _handle = handle;
        }
        
        public void Release()
        {
            _handle.Dispose();
        }
    }
}
