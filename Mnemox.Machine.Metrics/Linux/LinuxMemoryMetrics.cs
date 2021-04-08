using Mnemox.Machine.Metrics.Structures;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetrics : IMemoryMetrics
    {
        private readonly ILinuxMemoryMetricsHelpers _linuxMemoryMetricsHelpers;

        private readonly ILinuxCommandsHelper _linuxCommandsHelper;

        public LinuxMemoryMetrics(
            ILinuxMemoryMetricsHelpers linuxMemoryMetricsHelpers, 
            ILinuxCommandsHelper linuxCommandsHelper)
        {
            _linuxMemoryMetricsHelpers = linuxMemoryMetricsHelpers;

            _linuxCommandsHelper = linuxCommandsHelper;
        }

        public ulong GetAvailableBytes()
        {
            var freeCommandOutput = _linuxCommandsHelper.ExecuteBashCommand(LinuxCommands.GET_MEMORY_METRICS);

            var metrics = _linuxMemoryMetricsHelpers.GetParsedMetrics(freeCommandOutput);

            return metrics.UsedBytes;
        }

        public ulong GetTotalPhysicalMemoryBytes()
        {
            var freeCommandOutput = _linuxCommandsHelper.ExecuteBashCommand(LinuxCommands.GET_MEMORY_METRICS);

            var metrics = _linuxMemoryMetricsHelpers.GetParsedMetrics(freeCommandOutput);

            return metrics.TotalBytes;
        }

        public ulong GetUsedMemoryBytes()
        {
            var freeCommandOutput = _linuxCommandsHelper.ExecuteBashCommand(LinuxCommands.GET_MEMORY_METRICS);

            var metrics = _linuxMemoryMetricsHelpers.GetParsedMetrics(freeCommandOutput);

            return metrics.UsedBytes;
        }
    }
}
