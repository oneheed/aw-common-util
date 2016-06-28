using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWCommonUtil
{
    public class ResourceUtil
    {
        private static PerformanceCounter cpuCounter;
        private static PerformanceCounter ramCounter;

        static ResourceUtil()
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public static float GetCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public static float GetAvailableMemory()
        {
            return ramCounter.NextValue(); ;
        }
    }
}
