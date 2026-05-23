using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Dre0Dru.Initialization
{
    public class InitializationSequence : IInitializationTask
    {
        private readonly List<IInitializationTask> _tasks = new();

        [RequiredMember]
        public InitializationSequence()
        {
        }

        public InitializationSequence AddTask(IInitializationTask task)
        {
            _tasks.Add(task);

            return this;
        }

        public async UniTask InitializeAsync(CancellationToken ct = default)
        {
            foreach (var loadingTask in _tasks)
            {
                await loadingTask.InitializeAsync(ct);
            }
        }
    }
}
