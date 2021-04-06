namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetricsHelpers : ILinuxCpuMetricsHelpers
    {
        public float GetCpuUsagePercentage(float total, float used)
        {
            var percent = 100 / total;

            var usedPercents = percent * used;

            return usedPercents;
        }
    }
}
