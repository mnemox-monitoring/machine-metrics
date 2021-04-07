using Mnemox.Machine.Metrics.Structures;
using System;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetricsHelpers : ILinuxMemoryMetricsHelpers
    {
        public LinuxMemoryMetricsStructure GetParsedMetrics(string metrics)
        {
            var lines = metrics.Split(Environment.NewLine);

            var headersSplit = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var metricsSplit = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var headersIndexes = FindHeaderIndexes(headersSplit);

            return new LinuxMemoryMetricsStructure
            {
                FreeBytes = Convert.ToUInt64(metricsSplit[headersIndexes.FreeIndex]),

                TotalBytes = Convert.ToUInt64(metricsSplit[headersIndexes.TotalIndex]),

                UsedBytes = Convert.ToUInt64(metricsSplit[headersIndexes.UsedIndex])
            };
        }

        private FreeMemoryHeadersIndexes FindHeaderIndexes(string[] headers)
        {
            var freeMemoryHeadersIndexes = new FreeMemoryHeadersIndexes();

            for (var i = 0; i < headers.Length; i++)
            {
                var headerIndex = i + 1;

                switch (headers[i].ToLower())
                {
                    case FreeMemoryHeaders.Total:
                        freeMemoryHeadersIndexes.TotalIndex = headerIndex;
                        break;
                    case FreeMemoryHeaders.Used:
                        freeMemoryHeadersIndexes.UsedIndex = headerIndex;
                        break;
                    case FreeMemoryHeaders.Free:
                        freeMemoryHeadersIndexes.FreeIndex = headerIndex;
                        break;
                }
            }

            return freeMemoryHeadersIndexes;
        }
    }
}
