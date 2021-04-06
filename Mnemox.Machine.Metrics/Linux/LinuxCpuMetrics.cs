using Mnemox.Machine.Metrics.Windows;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetrics : ICpuMetrics
    {
        public float GetCpuUsagePercentage()
        {
            throw new System.NotImplementedException();
        }

        public float GetCurrentProcessCpuUsagePercentage()
        {
            throw new System.NotImplementedException();
        }
    }
}
