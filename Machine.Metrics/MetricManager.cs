using Mnemox.Machine.Metrics.Structures;

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

            var metricsCollector = _metricsManagerHelpers.GetMetricsCollector(osPaltform);

            var cpuUsage = metricsCollector.GetCpuUsage();

            return new OsMetrics
            {
                CpuUsage = cpuUsage
            };
        }
    }
}
