using Dre0Dru.Pool;
using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    public class ReturnToPoolStrategy : MonoBehaviour, IDestroyStrategy
    {
        public void Destroy()
        {
            if (TryGetComponent<IPooledObject>(out var pooledObject))
            {
                pooledObject.Release();
            }
        }
    }
}