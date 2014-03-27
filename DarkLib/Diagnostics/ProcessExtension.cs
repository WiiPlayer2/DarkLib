//-----------------------------------------------------------------------
// <copyright file="ProcessExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace System.Diagnostics
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Diagnostics.Process"/>
    /// </summary>
    public static class ProcessExtension
    {
        /// <summary>
        /// Contains the last time a process with the given id was checked.
        /// </summary>
        private static Dictionary<int, DateTime> cpuCheckTimes;

        /// <summary>
        /// Contains the last total CPU time of a process with the given id.
        /// </summary>
        private static Dictionary<int, TimeSpan> cpuTimes;
        
        /// <summary>
        /// Initializes static members of the <see cref="ProcessExtension" /> class.
        /// </summary>
        static ProcessExtension()
        {
            cpuTimes = new Dictionary<int, TimeSpan>();
            cpuCheckTimes = new Dictionary<int, DateTime>();
        }

        /// <summary>
        /// Calculates the average CPU usage of the given process.
        /// </summary>
        /// <param name="process">The process</param>
        /// <returns>Percentage of the average CPU usage</returns>
        public static double GetCpuUsage(this Process process)
        {
            process.Refresh();
            if (!cpuTimes.ContainsKey(process.Id))
            {
                InitCpuUsage(process);
            }

            var newTime = process.TotalProcessorTime;
            var now = DateTime.UtcNow;

            var cpuDiff = (newTime - cpuTimes[process.Id]).TotalSeconds;
            var timeDiff = (now - cpuCheckTimes[process.Id]).TotalSeconds;
            var usage = cpuDiff / (Environment.ProcessorCount * timeDiff);

            cpuTimes[process.Id] = newTime;
            cpuCheckTimes[process.Id] = now;

            return usage;
        }

        /// <summary>
        /// Initializes the calculation of the CPU usage of the given process.
        /// </summary>
        /// <param name="process">The process</param>
        public static void InitCpuUsage(this Process process)
        {
            cpuTimes[process.Id] = process.TotalProcessorTime;
            cpuCheckTimes[process.Id] = DateTime.UtcNow;
        }
    }
}