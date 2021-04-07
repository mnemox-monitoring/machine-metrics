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

            var memoryMestrics = memoryMetricsCollector.GetTotalPhysicalMemory();

            var cpuMetricsCollector = _metricsManagerHelpers.GetCpuMetricsCollector(osPaltform);

            var totalCpuUsagePercentage = cpuMetricsCollector.GetCpuUsagePercentage();

            return new OsMetrics
            {
                TotalCpuUsagePercentage = Math.Round(totalCpuUsagePercentage, 2),

                CapacityBytes = memoryMestrics.CapaciyBytes
            };
        }
    }
}
