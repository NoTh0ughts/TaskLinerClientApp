using System;
using System.Diagnostics;

namespace TaskLinerClientApp
{ 
    public static class TimeService
    {
        public static TimeSpan UpTime
        {
            get
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
        }

        public static Stopwatch AppStartTime { get; private set; }

        public static void Initialize()
        {
            AppStartTime = Stopwatch.StartNew();
        }
    }
}
