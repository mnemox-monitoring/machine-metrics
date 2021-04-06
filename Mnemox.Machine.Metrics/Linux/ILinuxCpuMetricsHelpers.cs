namespace Mnemox.Machine.Metrics.Linux
{
    public interface ILinuxCpuMetricsHelpers
    {
        float GetCpuUsagePercentage(float total, float used);
    }
}