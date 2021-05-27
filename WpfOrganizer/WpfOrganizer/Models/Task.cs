using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class Task : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private string description;
        public string Description { get => description; set => Set(ref description, value); }

        private Tag tag;
        public Tag Tag { get => tag; set => Set(ref tag, value); }

        private bool isChecked = false;
        public bool Checked
        {
            get => isChecked;
            set
            {
                Set(ref isChecked, value);
                OnTaskCompleted?.Invoke(value);
            }
        }

        private bool deadlineEnabled;
        public bool DeadlineEnabled
        {
            get => deadlineEnabled;
            set
            {
                Set(ref deadlineEnabled, value);
                
                if (value)
                    if (DeadlineTime == null)
                        DeadlineTime = DateTime.Now;
                    else
                        DeadlineTime = null;
            }
        }

        private DateTime? deadlineTime;
        public DateTime? DeadlineTime { get => deadlineTime; set => Set(ref deadlineTime, value); }

        private TimeSpan? timeLeft;
        public TimeSpan? TimeLeft { get => timeLeft; set => Set(ref timeLeft, value); }

        private int timeProgress;
        public int TimeProgress { get => timeProgress; set => Set(ref timeProgress, value); }

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<TaskImage> Images { get; set; }

        private bool forCreation = false;
        public bool ForCreation { get => forCreation; set => Set(ref forCreation, value); }

        public delegate void TaskCompleted(bool completed);
        public event TaskCompleted OnTaskCompleted;

        public Task()
        {
            SetImages(null);
            SetCheckLists(null);

            TagManager.Inst.OnTagRemoved += TagManager_OnTagRemoved;
            TimeManager.Inst.OnTimeUpdated += TimeManager_OnTimeUpdated;
        }

        public void SetImages(List<TaskImage> images)
        {
            Images = images != null ? new ObservableCollection<TaskImage>() : new ObservableCollection<TaskImage>(images);
            Images.CollectionChanged += Images_CollectionChanged;
        }

        public void SetCheckLists(List<CheckList> lists)
        {
            CheckLists = lists != null ? new ObservableCollection<CheckList>() : new ObservableCollection<CheckList>(lists);
            CheckLists.CollectionChanged += CheckLists_CollectionChanged;
        }

        private void TimeManager_OnTimeUpdated(DateTime now)
        {
            if (DeadlineTime != null)
            {
                TimeLeft = DeadlineTime - now;
                TimeSpan totalTimeSpan = (TimeSpan)(DeadlineTime - DateTime.Today);
                double totalSeconds = totalTimeSpan.TotalSeconds;
                double timeLeft = ((TimeSpan)TimeLeft).TotalSeconds;
                TimeProgress = (int)(timeLeft / totalSeconds * (double)100);

                System.Diagnostics.Trace.WriteLine($"{(int)(timeLeft - 1)}, {(int)(timeLeft)}, {timeLeft}");

                if (!ForCreation && !Checked)
                {
                    if ((int)timeLeft == 0) // Это просто ужасно, просто кошмарно, но времени на норм решение нету
                        if (timeLeft > 0)
                            NotificationsManager.ShowTaskExpired(Name);
                        else
                            NotificationsManager.ShowTaskWarning(Name, (TimeSpan)TimeLeft);
                }
            }
            else
                TimeLeft = null;

        }

        private void TagManager_OnTagRemoved(Tag removedTag)
        {
            if (removedTag == Tag)
                Tag = null;
        }

        public bool IsValid() => !String.IsNullOrEmpty(Name);

        private void CheckLists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("CheckLists");
        }

        private void Images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Images");
        }
    }
}
