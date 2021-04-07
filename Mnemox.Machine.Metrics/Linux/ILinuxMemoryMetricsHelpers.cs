using Mnemox.Machine.Metrics.Structures;

namespace Mnemox.Machine.Metrics.Linux
{
    public interface ILinuxMemoryMetricsHelpers
    {
        LinuxMemoryMetricsStructure GetParsedMetrics(string metrics);
    }
}