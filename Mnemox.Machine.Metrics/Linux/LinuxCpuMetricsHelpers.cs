using System;
using System.Text.RegularExpressions;

namespace Mnemox.Machine.Metrics.Linux
{
    public class LinuxCpuMetricsHelpers : ILinuxCpuMetricsHelpers
    {
        private const string CPU_LINE_INDICATOR = "cpu";

        private const string SPLIT_LINE_CHARACTER = ",";

        private const string IDLE_CPU_INDICATOR = "id";

        public double? GetCpuUsageFromTopCommandResult(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new ArgumentNullException(nameof(result));
            }

            var split = result.Split(Environment.NewLine);

            if(split.Length > 0)
            {
                foreach (var item in split)
                {
                    if (item.ToLower().Contains(CPU_LINE_INDICATOR))
                    {
                        var splitLine = item.Split(SPLIT_LINE_CHARACTER);

                        if(splitLine.Length > 0)
                        {
                            foreach(var lineItem in splitLine)
                            {
                                var lineItemToLower = lineItem.ToLower();

                                if (lineItemToLower.Contains(IDLE_CPU_INDICATOR))
                                {
                                    var cpuUsagePercentage = GetNumbers(lineItemToLower);

                                    return 100.0 - double.Parse(cpuUsagePercentage);
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        private string GetNumbers(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }
    }
}
