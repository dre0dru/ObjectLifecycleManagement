using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    public class DestroyGameObjectStrategy : MonoBehaviour, IDestroyStrategy
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}