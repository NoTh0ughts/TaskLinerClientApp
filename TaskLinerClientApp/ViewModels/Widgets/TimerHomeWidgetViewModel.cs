using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TaskLinerClientApp.ViewModels.Widgets
{
    public class TimerHomeWidgetViewModel : ViewModelBase
    {
        public string WorkedTimeFormatted => WorkedTime.ToString(@"hh\:mm\:ss");
        public TimeSpan WorkedTime => _workerTimer.Elapsed;
        public TimeSpan PausedTime => WorkedTime - TimeService.AppStartTime.Elapsed;
        public bool IsRunning => _workerTimer.IsRunning;

        private readonly DispatcherTimer _dispatcher;
        private readonly Stopwatch _workerTimer;

        public TimerHomeWidgetViewModel()
        {
            _dispatcher = new DispatcherTimer();
            _dispatcher.Tick += new EventHandler(DispatcherTick);
            _dispatcher.Interval = new TimeSpan(0, 0, 1);
            _dispatcher.Start();

            _workerTimer = Stopwatch.StartNew();
        }

        public void DispatcherTick(object sender, EventArgs e)
        {
            if(_workerTimer.IsRunning)
            {
                OnPropertyChanged(nameof(WorkedTimeFormatted));
            }
        }

        public void StartTimer()
        {
            if (_workerTimer.IsRunning is false)
            {
                _workerTimer.Start();
            }
        }
        public void StopTimer()
        {
            if (_workerTimer.IsRunning)
            {
                _workerTimer.Stop();
            }
        }
    }
}
