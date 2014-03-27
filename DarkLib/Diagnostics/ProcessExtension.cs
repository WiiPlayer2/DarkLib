using System;
using System.Collections.Generic;

namespace System.Diagnostics
{
    public static class ProcessExtension
    {
        private static Dictionary<int, DateTime> cpuCheckTimes;
        private static Dictionary<int, TimeSpan> cpuTimes;

        static ProcessExtension()
        {
            cpuTimes = new Dictionary<int, TimeSpan>();
            cpuCheckTimes = new Dictionary<int, DateTime>();
        }

        public static double GetCpuUsage(this Process @Process)
        {
            @Process.Refresh();
            if (!cpuTimes.ContainsKey(@Process.Id))
            {
                InitCpuUsage(@Process);
            }

            var newTime = @Process.TotalProcessorTime;
            var now = DateTime.UtcNow;

            var cpuDiff = (newTime - cpuTimes[@Process.Id]).TotalSeconds;
            var timeDiff = (now - cpuCheckTimes[@Process.Id]).TotalSeconds;
            var usage = cpuDiff / (Environment.ProcessorCount * timeDiff);

            cpuTimes[@Process.Id] = newTime;
            cpuCheckTimes[@Process.Id] = now;

            return usage;
        }

        public static void InitCpuUsage(this Process @Process)
        {
            cpuTimes[@Process.Id] = @Process.TotalProcessorTime;
            cpuCheckTimes[@Process.Id] = DateTime.UtcNow;
        }
    }
}