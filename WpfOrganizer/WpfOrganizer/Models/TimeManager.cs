using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace WpfOrganizer.Models
{
    class TimeManager
    {
        private static TimeManager instance;
        public static TimeManager Inst
        {
            get => instance ?? (instance = new TimeManager());
            set { }
        }

        public delegate void TimeUpdated(DateTime now);
        public event TimeUpdated OnTimeUpdated;

        public DateTime Now;

        public TimeManager()
        {
            // Create a timer with a two second interval.
            var timer = new Timer(500);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += UpdateTime;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void UpdateTime(object sender, ElapsedEventArgs e)
        {
            Now = DateTime.Now;
            OnTimeUpdated?.Invoke(Now);
        }
    }
}
