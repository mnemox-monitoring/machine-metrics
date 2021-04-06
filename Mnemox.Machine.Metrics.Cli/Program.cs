using System;
using System.Diagnostics;

namespace Mnemox.Machine.Metrics.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            var metricManager = new MetricManager(new MetricsManagerHelpers());

            var metrics = metricManager.GetOsMetrics();

            Console.WriteLine();
            Console.WriteLine("****** Mnemox Metrics ********************");
            Console.WriteLine();
            Console.WriteLine($"Total memory bytes: {metrics.CapacityBytes}");
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();

            try
            {
                GetCpuUsage();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetCpuUsage()
        {

                var output = "";

                var info = new ProcessStartInfo("top")
                {
                    FileName = "/bin/bash",

                    Arguments = "top -b -n2 -p 1 | fgrep \"Cpu(s)\" | tail -1 | awk -F'id,' -v prefix=\"$prefix\" '{ split($1, vs, \",\"); v=vs[length(vs)]; sub(\"%\", \"\", v); printf \"%s%.1f%%\n\", prefix, 100 - v }'",

                    RedirectStandardOutput = true
                };

                using (var process = Process.Start(info))
                {
                    output = process.StandardOutput.ReadToEnd();
                }

               
        }
    }
}
