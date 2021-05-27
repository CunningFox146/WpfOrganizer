using System;
using System.Collections.Generic;
using WpfOrganizer.Util;
using WpfOrganizer.Models;
using System.Windows.Input;
using WpfOrganizer.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace WpfOrganizer.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private static MainViewModel currentInstance;
        public static MainViewModel inst
        {
            get => currentInstance;
            set { }
        }

        #region Команды

        public ICommand RemoveCheckListItemCommand { get; }
        private bool OnCanRemoveCheckListItemCommand(object p) => true;
        private void OnRemoveCheckListItemCommand(object p)
        {
            var values = (object[])p;
            if (values == null) return;

            var item = values[0] as CheckListItem;
            var checkList = values[1] as CheckList;

            if (checkList == null || item == null) return;

            checkList.Items.Remove(item);

            if (checkList.Items.Count == 0)
                SelectedTask.CheckLists.Remove(checkList);
        }

        public ICommand AddCheckBoxCommand { get; }
        private bool OnCanAddCheckBoxCommand(object p) => true;
        private void OnAddCheckBoxCommand(object p)
        {
            var checkList = p as CheckList;
            if (checkList == null) return;

            checkList.Items.Add(new CheckListItem(checkList) { Name = "New Check List Item" });
        }
        
        public ICommand RemoveCheckListCommand { get; }
        private bool OnCanRemoveCheckListCommand(object p) => true;
        private void OnRemoveCheckListCommand(object p)
        {
            var checkList = p as CheckList;
            if (checkList == null) return;

            SelectedTask.CheckLists.Remove(checkList);
        }

        public ICommand RemoveImageCommand { get; }
        private bool OnCanRemoveImageCommand(object p) => true;
        private void OnRemoveImageCommand(object p)
        {
            var image = p as TaskImage;
            if (image == null) return;

            SelectedTask.Images.Remove(image);
        }

        public ICommand RemoveSelectedTaskCommand { get; }
        private bool OnCanRemoveSelectedTaskCommand(object p) => true;
        private void OnRemoveSelectedTaskCommand(object p)
        {
            Tasks.Remove(SelectedTask);
            SetupTaskForCreation();
        }

        public ICommand AddImageCommand { get; }
        private bool OnCanAddImageCommand(object p) => true;
        private void OnAddImageCommand(object p)
        {
            if (SelectedTask == null) return;

            var dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";

            if (dlg.ShowDialog() == true)
            {
                SelectedTask.Images.Add(new TaskImage(dlg.FileName));
                //OnPropertyChanged("SelectedTask");
                //SelectedImageTextBlock.Text = System.IO.Path.GetFileName(dlg.FileName);
                //ImgPreview.Source = selectedImg;
            }
        }

        public ICommand AddCheckListCommand { get; }
        private bool OnCanAddCheckListCommand(object p) => true;
        private void OnAddCheckListCommand(object p)
        {
            

            var checkList = new CheckList() { Name = "New Check List" };

            var checkListItem = new CheckListItem(checkList)
            {
                Name = "New Check List Item"
            };

            checkList.Items.Add(checkListItem);

            SelectedTask.CheckLists.Add(checkList);
        }
        
        public ICommand AddTaskCommand { get; }
        private bool OnCanAddTaskCommand(object p) => SelectedTask != null && SelectedTask.IsValid();
        private void OnAddTaskCommand(object p)
        {
            SelectedTask.ForCreation = false;
            Tasks.Add(SelectedTask);
            //SetupTaskForCreation();
        }

        public ICommand SetCreationMode { get; }
        private bool OnCanSetCreationMode(object p) => SelectedTask != null && !SelectedTask.ForCreation;
        private void OnSetCreationMode(object p)
        {
            SetupTaskForCreation();
        }

        public ICommand CreateTagCommand { get; }
        private bool OnCanCreateTagCommand(object p) => !String.IsNullOrEmpty(CreatingTag.Name);
        private void OnCreateTagCommand(object p)
        {
            Tags.Add(CreatingTag);
            CreatingTag = new Tag();
        }

        public ICommand RemoveTagCommand { get; }
        private bool OnCanRemoveTagCommand(object p) => true;
        private void OnRemoveTagCommand(object p)
        {
            Tag tag = p as Tag;
            if (tag != null)
            {
                TagManager.Inst.RemoveTag(tag);
                Tags.Remove(tag);
            }
        }

        public ICommand SetDateCommand { get; }
        private bool OnCanSetDateCommand(object p) => true;
        private void OnSetDateCommand(object p)
        {
            TaskData data = TaskPicker.Inst.GetTaskData(SelectedDate);

            if (data != null)
                ChangeDate(data.Tasks, data.Tags);
        }

        public ICommand SettingsCommand { get; }
        private bool OnCanSettingsCommand(object p) => true;
        private void OnSettingsCommand(object p)
        {
            MainWindowViewModel.Inst.CurrentView = AppViews.Settings;
        }

        //public ICommand SortCommand { get; }
        //private bool OnCanSortCommand(object p) => true;
        //private void OnSortCommand(object p)
        //{
        //    Tasks.Sort();
        //}

        #endregion

        private DateTime currentDateTime;
        public DateTime CurrentDateTime { get => currentDateTime; set => Set(ref currentDateTime, value); }

        private DateTime selectedDate;
        public DateTime SelectedDate { get => selectedDate; set => Set(ref selectedDate, value); }

        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks { get => tasks; set => Set(ref tasks, value); }

        // Используется не только для выборки, но и для создания
        private Task selectedTask;
        public Task SelectedTask { get => selectedTask; set => Set(ref selectedTask, value); }

        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags { get => tags; set => Set(ref tags, value); }

        private Tag creatingTag;
        public Tag CreatingTag { get => creatingTag; set => Set(ref creatingTag, value); }

        //private Tag searchTag;
        //public Tag SearchTag { get => SearchTag; set => Set(ref searchTag, value); }


        public MainViewModel()
        {
            currentInstance = this;

            #region Команды

            AddImageCommand = new LambdaCommand(OnAddImageCommand, OnCanAddImageCommand);
            SetCreationMode = new LambdaCommand(OnSetCreationMode, OnCanSetCreationMode);
            CreateTagCommand = new LambdaCommand(OnCreateTagCommand, OnCanCreateTagCommand);
            RemoveTagCommand = new LambdaCommand(OnRemoveTagCommand, OnCanRemoveTagCommand);
            AddCheckListCommand = new LambdaCommand(OnAddCheckListCommand, OnCanAddCheckListCommand);
            AddTaskCommand = new LambdaCommand(OnAddTaskCommand, OnCanAddTaskCommand);
            RemoveSelectedTaskCommand = new LambdaCommand(OnRemoveSelectedTaskCommand, OnCanRemoveSelectedTaskCommand);
            RemoveImageCommand = new LambdaCommand(OnRemoveImageCommand, OnCanRemoveImageCommand);
            AddCheckBoxCommand = new LambdaCommand(OnAddCheckBoxCommand, OnCanAddCheckBoxCommand);
            RemoveCheckListCommand = new LambdaCommand(OnRemoveCheckListCommand, OnCanRemoveCheckListCommand);
            RemoveCheckListItemCommand = new LambdaCommand(OnRemoveCheckListItemCommand, OnCanRemoveCheckListItemCommand);
            SetDateCommand = new LambdaCommand(OnSetDateCommand, OnCanSetDateCommand);
            SettingsCommand = new LambdaCommand(OnSettingsCommand, OnCanSettingsCommand);
            //SortCommand = new LambdaCommand(OnSortCommand, OnCanSortCommand);

            #endregion

            #region Инициализация

            //SetupTaskForCreation();
            CreatingTag = new Tag();
            SelectedDate = DateTime.Today;

            CurrentDateTime = TimeManager.Inst.Now;
            TimeManager.Inst.OnTimeUpdated += TimeManager_OnTimeUpdated;

            #endregion 
        }

        public void ChangeDate(ObservableCollection<Task> tasks, ObservableCollection<Tag> tags)
        {
            SetTasks(tasks);
            SetTags(tags);

            SetupTaskForCreation();
            CreatingTag = new Tag();
        }

        private void SetTasks(ObservableCollection<Task> tasks)
        {
            if (Tasks != null)
            {
                Tasks.CollectionChanged -= Tasks_CollectionChanged;
            }

            Tasks = tasks;
            Tasks.CollectionChanged += Tasks_CollectionChanged;
            OnPropertyChanged("Tasks");
        }

        private void SetTags(ObservableCollection<Tag> tags)
        {
            if (Tags != null)
            {
                Tags.CollectionChanged -= Tags_CollectionChanged;
            }

            Tags = tags;
            Tags.CollectionChanged += Tags_CollectionChanged;
            OnPropertyChanged("Tags");
        }

        private void SetupTaskForCreation()
        {
            SelectedTask = new Task();
            SelectedTask.ForCreation = true;
            SelectedTask.OnTaskCompleted += SelectedTask_OnTaskCompleted;
        }

        #region Ивенты

        private void TimeManager_OnTimeUpdated(DateTime now)
        {
            CurrentDateTime = now;
        }

        private void SelectedTask_OnTaskCompleted(bool completed)
        {
            OnPropertyChanged("Tasks");
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Tasks");
        }

        private void Tags_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Tags");
        }

        #endregion
    }
}
