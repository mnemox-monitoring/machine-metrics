namespace Mnemox.Machine.Metrics.Linux
{
    public interface ILinuxMemoryMetricsHelpers
    {
        string GetFreeCommandOutput();
        LinuxMemoryMetricsStructure GetParsedMetrics(string metrics);
    }
}