using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Dre0Dru.Initialization
{
    public class DelegateInitializationTask : IInitializationTask
    {
        private readonly Func<CancellationToken, UniTask> _delegate;

        [RequiredMember]
        public DelegateInitializationTask(Func<CancellationToken, UniTask> @delegate)
        {
            _delegate = @delegate;
        }

        public UniTask InitializeAsync(CancellationToken ct = default)
        {
            return _delegate(ct);
        }
    }
}
