using Mnemox.Machine.Metrics.Structures;
using System;

namespace Mnemox.Machine.Metrics
{
    public class MetricManager : IMetricManager
    {
        private readonly IMetricsManagerHelpers _metricsManagerHelpers;

        public MetricManager(IMetricsManagerHelpers metricsManagerHelpers)
        {
            _metricsManagerHelpers = metricsManagerHelpers;
        }

        public OsMetrics GetOsMetrics()
        {
            var osPaltform = _metricsManagerHelpers.DetectOsPlatform();

            var memoryMetricsCollector = _metricsManagerHelpers.GetMemoryMetricsCollector(osPaltform);

            var totalPhysicalMemoryBytes = memoryMetricsCollector.GetTotalPhysicalMemoryBytes();

            var totalUsedMemoryBytes = memoryMetricsCollector.GetUsedMemoryBytes();

            var cpuMetricsCollector = _metricsManagerHelpers.GetCpuMetricsCollector(osPaltform);

            var totalCpuUsagePercentage = cpuMetricsCollector.GetCpuUsagePercentage();

            var currentProcessCpuUsagePercentage = cpuMetricsCollector.GetCurrentProcessCpuUsagePercentage();

            var memoryUsedPercents = _metricsManagerHelpers.GetMemoryUsedPercents(totalPhysicalMemoryBytes, totalUsedMemoryBytes);

            return new OsMetrics
            {
                TotalCpuUsagePercentage = Math.Round(totalCpuUsagePercentage, 2),

                CurrentProcessCpuUsagePercentage = Math.Round(currentProcessCpuUsagePercentage, 2),

                MemoryCapacityBytes = totalPhysicalMemoryBytes,

                MemoryUsedBytes = totalUsedMemoryBytes,

                MemoryUsedPercents = Math.Round(memoryUsedPercents, 2)
            };
        }
    }
}
