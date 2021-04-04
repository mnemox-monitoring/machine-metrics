using Mnemox.Machine.Metrics.Windows;
using System.Runtime.InteropServices;

namespace Mnemox.Machine.Metrics
{
    public interface IMetricsManagerHelpers
    {
        OSPlatform DetectOsPlatform();
        ICpuMetrics GetCpuMetricsCollector(OSPlatform osPlatform);
        IMemoryMetrics GetMemoryMetricsCollector(OSPlatform osPlatform);
    }
}