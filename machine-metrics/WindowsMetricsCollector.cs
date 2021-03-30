using System;
using System.Diagnostics;
using System.Threading;

namespace machine_metrics
{
    public class WindowsMetricsCollector : IMetrics
    {
        private const int SLEEP_BETWEEN_CALLS = 1000;

        public float GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

            var value = cpuCounter.NextValue();

            if (Math.Abs(value) <= 0.00)
            {
                Thread.Sleep(SLEEP_BETWEEN_CALLS);// as per documentation

                value = cpuCounter.NextValue();
            }

            return value;
        }
    }
}
