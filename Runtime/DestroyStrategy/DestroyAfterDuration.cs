using UnityEngine;

namespace Dre0Dru.DestroyStrategy
{
    //TODO как стартовать и останавливать?
    public class DestroyAfterDuration : MonoBehaviour
    {
        [SerializeField]
        private float _duration;
        private float _startTime;

        public void Start()
        {
            enabled = true;
            _startTime = Time.time;
        }

        public void Stop()
        {
            enabled = false;
        }

        private void Update()
        {
            if (_startTime + _duration < Time.time)
            {
                this.ExecuteDestroyStrategy();
                Stop();
            }
        }

        public DestroyAfterDuration SetDuration(float duration)
        {
            _duration = duration;

            return this;
        }
    }
}
