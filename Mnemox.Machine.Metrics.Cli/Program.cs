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
            Console.WriteLine($"Memory total(bytes):   {metrics.MemoryCapacityBytes}");
            Console.WriteLine($"Memory used(bytes):    {metrics.MemoryUsedBytes}");
            Console.WriteLine($"Memory used(%):        {metrics.MemoryUsedPercents}");
            Console.WriteLine($"Total CPU usage(%):    {metrics.TotalCpuUsagePercentage}");
            Console.WriteLine($"Process CPU usage(%):  {metrics.CurrentProcessCpuUsagePercentage}");
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();
        }
    }
}
