using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLinerClientApp
{
    /// <summary>
    /// CLIENT ONLY!!!!
    /// </summary>
    public class WorkingTimer
    {
        public string WorkedTimeFormatted => WorkedTime.ToString(@"hh\:mm\:ss");
        public TimeSpan WorkedTime => WorkerTimer.Elapsed;
        public TimeSpan PausedTime => WorkedTime - TimeService.AppStartTime.Elapsed;
        public bool IsRunning => WorkerTimer.IsRunning;


        private Stopwatch WorkerTimer;

        public WorkingTimer()
        {
            WorkerTimer = Stopwatch.StartNew();
            WorkerTimer.Stop();
        }
        public void StartTimer()
        {
            if (WorkerTimer.IsRunning is false)
            {
                WorkerTimer.Start();
            }
        }
        public void StopTimer()
        {
            if(WorkerTimer.IsRunning)
            {
                WorkerTimer.Stop();
            }
        }
    }
}
