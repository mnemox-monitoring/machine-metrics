using System.Runtime.InteropServices;

namespace Mnemox.Machine.Metrics
{
    public interface IMetricsManagerHelpers
    {
        OSPlatform DetectOsPlatform();
        IMetrics GetMetricsCollector(OSPlatform osPlatform);
    }
}