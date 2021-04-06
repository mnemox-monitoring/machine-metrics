namespace Mnemox.Machine.Metrics.Windows
{
    public interface ICpuMetrics
    {
        float GetCpuUsagePercentage();
        float GetCurrentProcessCpuUsagePercentage();
    }
}