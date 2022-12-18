using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    //TODO as extension method
    //TODO manual start/pause?
    public class ExecuteDestroyStrategyAfterDuration : MonoBehaviour
    {
        [SerializeField]
        private float _duration;
        private float _startTime;

        private void Update()
        {
            if (_startTime + _duration < Time.time)
            {
                this.ExecuteDestroyStrategy();
                Destroy(this);
            }
        }

        public ExecuteDestroyStrategyAfterDuration SetDuration(float duration)
        {
            _startTime = Time.time;
            _duration = duration;

            return this;
        }
    }
}
