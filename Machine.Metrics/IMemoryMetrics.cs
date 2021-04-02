using Mnemox.Machine.Metrics.Structures;
using System.Collections.Generic;

namespace Mnemox.Machine.Metrics
{
    public interface IMemoryMetrics
    {        
        PhysicalMemory GetTotalPhysicalMemory();

        List<PhysicalMemory> GetPhysicalMemory();

        ulong GetMemoryAvailableBytes();
    }
}