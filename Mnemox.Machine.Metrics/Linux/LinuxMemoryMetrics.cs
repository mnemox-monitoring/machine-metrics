using Mnemox.Machine.Metrics.Structures;
using System;
using System.Collections.Generic;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetrics : IMemoryMetrics
    {
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
    }
}
