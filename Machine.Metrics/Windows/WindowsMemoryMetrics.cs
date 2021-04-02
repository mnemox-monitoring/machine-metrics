using Mnemox.Machine.Metrics.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace Mnemox.Machine.Metrics.Windows
{
    public class WindowsMemoryMetrics : IMemoryMetrics
    {
        private const string SELECT_PHYSICAL_MEMORY = "SELECT * FROM Win32_PhysicalMemory";

        private const string PHYSICAL_MEMORY_CAPACITY_PROPERTY = "Capacity";

        public PhysicalMemory GetTotalPhysicalMemory()
        {
            var memoryAvailableBytes = GetPhysicalMemory();

            if (memoryAvailableBytes.Count == 0)
            {
                throw new ArgumentNullException($"Can't get physical memory '{SELECT_PHYSICAL_MEMORY}'");
            }

            ulong bytes = 0;

            foreach (var item in memoryAvailableBytes)
            {
                bytes += item.CapaciyBytes;
            }

            var physicalMemory = new PhysicalMemory
            {
                CapaciyBytes = bytes
            };

            return physicalMemory;
        }

        /// <summary>
        /// List of available objects for ManagementObjectSearcher
        /// https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes
        /// </summary>
        /// <returns></returns>
        public List<PhysicalMemory> GetPhysicalMemory()
        {
            var physicalMemories = new List<PhysicalMemory>();

            var searcher = new ManagementObjectSearcher(SELECT_PHYSICAL_MEMORY);

            foreach (var WniPART in searcher.Get())
            {
                var capacity = Convert.ToUInt64(WniPART.Properties[PHYSICAL_MEMORY_CAPACITY_PROPERTY].Value);

                physicalMemories.Add(new PhysicalMemory
                {
                    CapaciyBytes = capacity
                });
            }

            return physicalMemories;
        }

        public ulong GetMemoryAvailableBytes()
        {
            var ramCounter = new PerformanceCounter("Memory", "Available Bytes");

            var value = Convert.ToUInt64(ramCounter.NextValue());

            return value;
        }
    }
}
