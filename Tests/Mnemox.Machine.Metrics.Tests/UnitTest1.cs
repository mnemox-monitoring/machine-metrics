using machine_metrics;
using System;
using Xunit;

namespace Mnemox.Machine.Metrics.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var windowsMetrics = new WindowsMetricsCollector();

            windowsMetrics.GetCpuUsage();
        }
    }
}
