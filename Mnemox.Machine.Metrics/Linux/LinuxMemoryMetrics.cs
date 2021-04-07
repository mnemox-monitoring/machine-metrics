using Mnemox.Machine.Metrics.Structures;
using System;
using System.Collections.Generic;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetrics : IMemoryMetrics
    {
        private readonly ILinuxMemoryMetricsHelpers _linuxMemoryMetricsHelpers;

        private readonly ILinuxCommandsHelper _linuxCommandsHelper;

        public LinuxMemoryMetrics(
            ILinuxMemoryMetricsHelpers linuxMemoryMetricsHelpers, 
            ILinuxCommandsHelper linuxCommandsHelper)
        {
            _linuxMemoryMetricsHelpers = linuxMemoryMetricsHelpers;

            _linuxCommandsHelper = linuxCommandsHelper;
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
            var freeCommandOutput = _linuxCommandsHelper.ExecuteBashCommand(LinuxCommands.GET_MEMORY_METRICS);

            var metrics = _linuxMemoryMetricsHelpers.GetParsedMetrics(freeCommandOutput);

            return new PhysicalMemory
            {
                CapaciyBytes = metrics.TotalBytes
            };
        }
    }
}
