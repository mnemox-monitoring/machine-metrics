namespace Mnemox.Machine.Metrics.Windows
{
    public interface ICpuMetrics
    {
        double GetCpuUsagePercentage();
        double GetCurrentProcessCpuUsagePercentage();
    }
}