using System;

namespace System.Timers
{
    public static class TimerExtension
    {
        public static void SetElapsedDate(this Timer @Timer, DateTime dateTime)
        {
            var now = DateTime.UtcNow;
            var utc = dateTime.ToUniversalTime();
            var diff = utc - now;
            @Timer.Interval = diff.TotalMilliseconds;
        }
    }
}