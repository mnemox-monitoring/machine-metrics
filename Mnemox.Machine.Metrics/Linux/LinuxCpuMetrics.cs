using Mnemox.Machine.Metrics.Structures;
using Mnemox.Machine.Metrics.Windows;
using System;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetrics : ICpuMetrics
    {
        private readonly ILinuxCommandsHelper _linuxCommandsHelper;

        private readonly ILinuxCpuMetricsHelpers _linuxCpuMetricsHelpers;

        public LinuxCpuMetrics(ILinuxCommandsHelper linuxCommandsHelper, ILinuxCpuMetricsHelpers linuxCpuMetricsHelpers)
        {
            _linuxCommandsHelper = linuxCommandsHelper;

            _linuxCpuMetricsHelpers = linuxCpuMetricsHelpers;
        }

        public double GetCpuUsagePercentage()
        {
            var metricsOutput = _linuxCommandsHelper.ExecuteBashCommand(LinuxCommands.GET_CPU_METRICS_FROM_TOP_COMMAND);

            var cpuUsagePercentage = _linuxCpuMetricsHelpers.GetCpuUsageFromTopCommandResult(metricsOutput);

            return cpuUsagePercentage ?? throw new NullReferenceException("Cpu usage cannot be retrieved");
        }

        public double GetCurrentProcessCpuUsagePercentage()
        {
            throw new NotImplementedException();
        }
    }
}
