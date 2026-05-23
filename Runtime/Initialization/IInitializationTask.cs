using System.Threading;
using Cysharp.Threading.Tasks;

namespace Dre0Dru.Initialization
{
    public interface IInitializationTask
    {
        UniTask InitializeAsync(CancellationToken ct = default);
    }
}
