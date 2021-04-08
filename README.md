### Machine Metrics Library helps to retrieve memory and CPU metrics on Windows and Linux Machines

#### Using example

```csharp
var metricManager = new MetricManager(new MetricsManagerHelpers());

var metrics = metricManager.GetOsMetrics();
```
- MemoryCapacityBytes -> Total memory in bytes
- MemoryUsedBytes     -> Used memory in bytes
- MemoryUsedPercents  -> Percents of used memory
- TotalCpuUsagePercentage -> Percents of used CPU
- CurrentProcessCpuUsagePercentage -> Percent of current process CPU usage
