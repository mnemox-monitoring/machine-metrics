using System;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxMemoryMetricsHelpers : ILinuxMemoryMetricsHelpers
    {
        #region consts

        private const string FILE_NAME = "/bin/bash";

        private const string PROCESS_NAME = "free";

        private const string ARGUMENTS = "-c \"free\"";

        #endregion

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

        public string GetFreeCommandOutput()
        {
            var output = "";

            var info = new ProcessStartInfo(PROCESS_NAME)
            {
                FileName = FILE_NAME,

                Arguments = ARGUMENTS,

                RedirectStandardOutput = true
            };

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            return output;
        }
    }
}
