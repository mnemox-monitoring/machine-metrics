namespace Mnemox.Machine.Metrics.Structures
{
    public class OsMetrics
    {
        public double TotalCpuUsagePercentage { get; set; }

        public double CurrentProcessCpuUsagePercentage { get; set; }

        public ulong MemoryCapacityBytes { get; set; }

        public ulong MemoryUsedBytes { get; set; }

        public double MemoryUsedPercents { get; set; }
    }
}
