//-----------------------------------------------------------------------
// <copyright file="TimerExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace System.Timers
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Timers.Timer"/>
    /// </summary>
    public static class TimerExtension
    {
        /// <summary>
        /// Sets the elapsed date.
        /// </summary>
        /// <param name="timer">The timer.</param>
        /// <param name="dateTime">The date time.</param>
        public static void SetElapsedDate(this Timer timer, DateTime dateTime)
        {
            var now = DateTime.UtcNow;
            var utc = dateTime.ToUniversalTime();
            var diff = utc - now;
            timer.Interval = diff.TotalMilliseconds;
        }
    }
}