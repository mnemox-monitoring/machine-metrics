using System;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Windows
{
    public class WindowsMemoryMetrics : IMemoryMetrics
    {
        private readonly IWindowsMemoryMetricsHelpers _windowsMemoryMetricsHelpers;

        public WindowsMemoryMetrics(IWindowsMemoryMetricsHelpers windowsMemoryMetricsHelpers)
        {
            _windowsMemoryMetricsHelpers = windowsMemoryMetricsHelpers;
        }

        public ulong GetTotalPhysicalMemoryBytes()
        {
            var memoryAvailableBytes = _windowsMemoryMetricsHelpers.GetPhysicalMemory();

            if (memoryAvailableBytes.Count == 0)
            {
                throw new ArgumentNullException($"Can't get physical memory '{WindowsMemoryMetricsHelpers.SELECT_PHYSICAL_MEMORY}'");
            }

            ulong bytes = 0;

            foreach (var item in memoryAvailableBytes)
            {
                bytes += item.CapaciyBytes;
            }

            return bytes;
        }

        public ulong GetAvailableBytes()
        {
            var ramCounter = new PerformanceCounter("Memory", "Available Bytes");

            var availableBytes = Convert.ToUInt64(ramCounter.NextValue());

            return availableBytes;
        }

        public ulong GetUsedMemoryBytes()
        {
            var totalPhysicalMemoryBytes = GetTotalPhysicalMemoryBytes();

            var availablePhysicalMemoryBytes = GetAvailableBytes();

            var usedMemoryBytes = totalPhysicalMemoryBytes - availablePhysicalMemoryBytes;

            return usedMemoryBytes;
        }
    }
}
