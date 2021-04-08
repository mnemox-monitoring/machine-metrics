using System;
using System.Diagnostics;
using System.Threading;

namespace Mnemox.Machine.Metrics.Windows
{
    public class WindowsCpuMetrics : ICpuMetrics
    {
        #region consts

        private const int SLEEP_BETWEEN_CALLS = 1000;

        private const string PERFORMANCE_COUNTER_PROCESSOR = "Processor Information";

        private const string PERFORMANCE_COUNTER_PROCESSOR_PERCENTS = "% Processor Utility";

        private const string PERFORMANCE_COUNTER_PROCESSOR_TOTAL = "_Total";

        private const string PERFORMANCE_COUNTER_PROCESS = "Process";

        private const string PERFORMANCE_COUNTER_PROCESSOR_TIME_PERCENTS = "% Processor Time";

        #endregion

        public double GetCpuUsagePercentage()
        {
            var performanceCounter = new PerformanceCounter(
                    PERFORMANCE_COUNTER_PROCESSOR,
                    PERFORMANCE_COUNTER_PROCESSOR_PERCENTS,
                    PERFORMANCE_COUNTER_PROCESSOR_TOTAL,
                    true
                );

            var value = performanceCounter.NextValue();

            if (Math.Abs(value) <= 0.00)
            {
                Thread.Sleep(SLEEP_BETWEEN_CALLS);

                value = performanceCounter.NextValue();
            }

            return value;
        }

        public double GetCurrentProcessCpuUsagePercentage()
        {
            var currentProcessName = Process.GetCurrentProcess().ProcessName;

            var performanceCounter = new PerformanceCounter(
                    PERFORMANCE_COUNTER_PROCESS,
                    PERFORMANCE_COUNTER_PROCESSOR_TIME_PERCENTS,
                    currentProcessName
                );

            var value = performanceCounter.NextValue();

            if (Math.Abs(value) <= 0.00)
            {
                Thread.Sleep(SLEEP_BETWEEN_CALLS);

                value = performanceCounter.NextValue();
            }

            return value;
        }
    }
}
