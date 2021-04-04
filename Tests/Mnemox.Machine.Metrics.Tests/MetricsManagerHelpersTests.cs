using Mnemox.Machine.Metrics.Linux;
using Mnemox.Machine.Metrics.Windows;
using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Mnemox.Machine.Metrics.Tests
{
    public class MetricsManagerHelpersTests
    {
        [Fact]
        public void GetMemoryMetricsCollector_Returns_WindowsMemoryMetrics_If_OS_Is_Windows()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetMemoryMetricsCollector(OSPlatform.Windows);

            Assert.IsType<WindowsMemoryMetrics>(metricsCollector);
        }

        [Fact]
        public void GetCpuMetricsCollector_Returns_WindowsCpuMetrics_If_OS_Is_Windows()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetCpuMetricsCollector(OSPlatform.Windows);

            Assert.IsType<WindowsCpuMetrics>(metricsCollector);
        }

        [Fact]
        public void GetMemoryMetricsCollector_Returns_LinuxMemoryMetrics_If_OS_Is_Linux()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetMemoryMetricsCollector(OSPlatform.Linux);

            Assert.IsType<LinuxMemoryMetrics>(metricsCollector);
        }

        [Fact]
        public void GetCpuMetricsCollector_Returns_LinuxCpuMetrics_If_OS_Is_Linux()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            var metricsCollector = target.GetCpuMetricsCollector(OSPlatform.Linux);

            Assert.IsType<LinuxCpuMetrics>(metricsCollector);
        }

        [Fact]
        public void GetMetricsCollector_ThrowsError_If_OS_unsupported()
        {
            var target = MnemoxMachineMetricsTestsHelpers.CreateMetricsManagerHelpersTarget();

            Assert.Throws<PlatformNotSupportedException>(() => target.GetMemoryMetricsCollector(OSPlatform.OSX));

            Assert.Throws<PlatformNotSupportedException>(() => target.GetMemoryMetricsCollector(OSPlatform.FreeBSD));
        }

        //[Fact]
        //public void A()
        //{
        //    var a = new WindowsMemoryMetrics().GetPhysicalMemory();

        //    var b = new WindowsMemoryMetrics().GetMemoryAvailableBytes();

        //    var c = new WindowsMemoryMetrics().GetCurrentProcessCpuUsagePercentage();
        //}
    }
}
