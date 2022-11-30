using Dre0Dru.ObjectExtensions;
using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    public static class DestroyStrategyExtensions
    {
        public static void ExecuteDestroyStrategy<TComponent>(this TComponent component)
            where TComponent : Component
        {
            if (component.TryGetComponent<IDestroyStrategy>(out var destroyStrategy))
            {
                destroyStrategy.Destroy();
            }
        }

        public static void ExecuteDestroyStrategy(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent<IDestroyStrategy>(out var destroyStrategy))
            {
                destroyStrategy.Destroy();
            }
        }

        public static DestroyAfterDuration DestroyAfterDuration<TComponent>(this TComponent component, float duration)
            where TComponent : Component =>
            component.GetOrAddComponent<DestroyAfterDuration>().SetDuration(duration);

        public static DestroyAfterDuration DestroyAfterDuration(this GameObject gameObject, float duration) =>
            gameObject.GetOrAddComponent<DestroyAfterDuration>().SetDuration(duration);

        public static TComponent WithDestroyStrategy<TComponent, TDestroyStrategy>(this TComponent component)
            where TComponent : Component
            where TDestroyStrategy : Component, IDestroyStrategy
        {
            component.GetOrAddComponent<TDestroyStrategy>();

            return component;
        }

        public static GameObject WithDestroyStrategy<TDestroyStrategy>(this GameObject gameObject)
            where TDestroyStrategy : Component, IDestroyStrategy
        {
            gameObject.GetOrAddComponent<TDestroyStrategy>();

            return gameObject;
        }
    }
}