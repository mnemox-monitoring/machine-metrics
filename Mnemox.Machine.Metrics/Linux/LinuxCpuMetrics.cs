using Mnemox.Machine.Metrics.Windows;
using System;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetrics : ICpuMetrics
    {
        private readonly ILinuxCpuMetricsHelpers _linuxCpuMetricsHelpers;

        public LinuxCpuMetrics(ILinuxCpuMetricsHelpers linuxCpuMetricsHelpers)
        {
            _linuxCpuMetricsHelpers = linuxCpuMetricsHelpers;
        }

        public float GetCpuUsagePercentage()
        {
            throw new NotImplementedException();
        }

        public float GetCurrentProcessCpuUsagePercentage()
        {
            throw new NotImplementedException();
        }
    }
}
