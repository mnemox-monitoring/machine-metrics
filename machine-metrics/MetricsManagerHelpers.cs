using machine_metrics;
using System;
using System.Runtime.InteropServices;

namespace Mnemox.Machine.Metrics
{
    public class MetricsManagerHelpers : IMetricsManagerHelpers
    {
        public OSPlatform DetectOsPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }
            throw new NotImplementedException("Unsupported OS type");
        }

        public IMetrics GetMetricsCollector(OSPlatform osPlatform)
        {
            if (osPlatform == OSPlatform.Windows)
            {
                return new WindowsMetricsCollector();
            }
            else if (osPlatform == OSPlatform.Linux)
            {
                return null;
            }

            throw new NotImplementedException("Unsupported OS type");
        }
    }
}
