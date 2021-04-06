using Mnemox.Machine.Metrics.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetrics : IMemoryMetrics
    {
        private readonly ILinuxMemoryMetricsHelpers _linuxMemoryMetricsHelpers;

        public LinuxMemoryMetrics(ILinuxMemoryMetricsHelpers linuxMemoryMetricsHelpers)
        {
            _linuxMemoryMetricsHelpers = linuxMemoryMetricsHelpers;
        }

        public ulong GetMemoryAvailableBytes()
        {
            throw new NotImplementedException();
        }

        public List<PhysicalMemory> GetPhysicalMemory()
        {
            throw new NotImplementedException();
        }

        public PhysicalMemory GetTotalPhysicalMemory()
        {
            var freeCommandOutput = _linuxMemoryMetricsHelpers.GetFreeCommandOutput();

            var metrics = _linuxMemoryMetricsHelpers.GetParsedMetrics(freeCommandOutput);

            return new PhysicalMemory
            {
                CapaciyBytes = metrics.TotalBytes
            };
        }
    }
}
