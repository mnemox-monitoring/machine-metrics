using System.Runtime.InteropServices;

namespace Mnemox.Machine.Metrics
{
    public interface IMetricsManagerHelpers
    {
        OSPlatform DetectOsPlatform();
        IMemoryMetrics GetMetricsCollector(OSPlatform osPlatform);
    }
}