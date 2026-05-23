using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Dre0Dru.Initialization
{
    public class InitializationParallelSequence : IInitializationTask
    {
        private readonly List<IInitializationTask> _tasks = new();

        [RequiredMember]
        public InitializationParallelSequence()
        {
        }

        public InitializationParallelSequence AddTask(IInitializationTask task)
        {
            _tasks.Add(task);

            return this;
        }

        public UniTask InitializeAsync(CancellationToken ct = default)
        {
            return UniTask.WhenAll(_tasks.Select(t => t.InitializeAsync(ct)));
        }
    }
}
