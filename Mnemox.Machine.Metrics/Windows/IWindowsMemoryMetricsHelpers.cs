using Mnemox.Machine.Metrics.Structures;
using System.Collections.Generic;

namespace Mnemox.Machine.Metrics.Windows
{
    public interface IWindowsMemoryMetricsHelpers
    {
        List<PhysicalMemory> GetPhysicalMemory();
    }
}