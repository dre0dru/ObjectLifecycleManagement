using Dre0Dru.ObjectExtensions;
using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    public static class DestroyStrategyExtensions
    {
        public static void ExecuteDestroyStrategy(this Component component) =>
            component.gameObject.ExecuteDestroyStrategy();

        public static void ExecuteDestroyStrategy(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent<IDestroyStrategy>(out var destroyStrategy))
            {
                destroyStrategy.Destroy();
            }
        }

        public static TDestroyStrategy WithDestroyStrategy<TDestroyStrategy>(this Component component)
            where TDestroyStrategy : Component, IDestroyStrategy =>
            component.gameObject.WithDestroyStrategy<TDestroyStrategy>();

        public static TDestroyStrategy WithDestroyStrategy<TDestroyStrategy>(this GameObject gameObject)
            where TDestroyStrategy : Component, IDestroyStrategy =>
            gameObject.GetOrAddComponent<TDestroyStrategy>();
        
    }
}
