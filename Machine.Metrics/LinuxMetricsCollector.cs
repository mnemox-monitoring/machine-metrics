using Mnemox.Machine.Metrics.Structures;
using System;
using System.Collections.Generic;

namespace Mnemox.Machine.Metrics
{
    public class LinuxMetricsCollector : IMemoryMetrics
    {
        public float GetCpuUsage()
        {
            throw new NotImplementedException();
        }

        public float GetCpuUsagePercentage()
        {
            throw new NotImplementedException();
        }

        public float GetCurrentProcessCpuUsagePercentage()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public float GetTotalPhysicalMemoryBytes()
        {
            throw new NotImplementedException();
        }
    }
}
