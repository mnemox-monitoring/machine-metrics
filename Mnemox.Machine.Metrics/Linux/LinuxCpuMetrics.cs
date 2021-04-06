using Mnemox.Machine.Metrics.Windows;
using System;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetrics : ICpuMetrics
    {
        private const string COMMAND_TO_GET_CPU_USAGE = "top -b -n2 -p 1 | fgrep \"Cpu(s)\" | tail -1 | awk -F'id,' -v prefix=\"$prefix\" '{ split($1, vs, \",\"); v=vs[length(vs)]; sub(\"%\", \"\", v); printf \"%s%.1f%%\n\", prefix, 100 - v }'";
        
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
