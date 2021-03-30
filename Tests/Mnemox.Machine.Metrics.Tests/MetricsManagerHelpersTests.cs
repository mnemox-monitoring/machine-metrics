using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Mnemox.Machine.Metrics.Tests
{
    public class MetricsManagerHelpersTests
    {
        [Fact]
        public void Returns_WindowsMetricsCollector_If_OS_Is_Windows()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetMetricsCollector(OSPlatform.Windows);

            Assert.IsType<WindowsMetricsCollector>(metricsCollector);
        }

        [Fact]
        public void Returns_LinuxMetricsCollector_If_OS_Is_Linux()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetMetricsCollector(OSPlatform.Linux);

            Assert.IsType<LinuxMetricsCollector>(metricsCollector);
        }

        [Fact]
        public void GetMetricsCollector_ThrowsError_If_OS_unsupported()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            Assert.Throws<NotImplementedException>(() => target.GetMetricsCollector(OSPlatform.OSX));

            Assert.Throws<NotImplementedException>(() => target.GetMetricsCollector(OSPlatform.FreeBSD));
        }
    }
}
