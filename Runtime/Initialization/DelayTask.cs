using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Dre0Dru.Initialization
{
    public class DelayTask : IInitializationTask
    {
        private readonly TimeSpan _delay;

        [RequiredMember]
        public DelayTask(TimeSpan delay)
        {
            _delay = delay;
        }

        public UniTask InitializeAsync(CancellationToken ct = default)
        {
            return UniTask.Delay(_delay, DelayType.Realtime, cancellationToken: ct);
        }
    }
}
