namespace Mnemox.Machine.Metrics.Linux
{
    public interface ILinuxCpuMetricsHelpers
    {
        double? GetCpuUsageFromTopCommandResult(string result);
    }
}