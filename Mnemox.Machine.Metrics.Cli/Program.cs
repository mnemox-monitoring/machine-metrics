using System;

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
        }
    }
}
