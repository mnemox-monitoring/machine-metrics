using Mnemox.Machine.Metrics.Structures;

namespace Mnemox.Machine.Metrics
{
    public interface IMemoryMetrics
    {        
        ulong GetTotalPhysicalMemoryBytes();

        ulong GetAvailableBytes();
        ulong GetUsedMemoryBytes();
    }
}