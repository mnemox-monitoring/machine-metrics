using Mnemox.Machine.Metrics.Structures;

namespace Mnemox.Machine.Metrics
{
    public interface IMetricManager
    {
        OsMetrics GetOsMetrics();
    }
}