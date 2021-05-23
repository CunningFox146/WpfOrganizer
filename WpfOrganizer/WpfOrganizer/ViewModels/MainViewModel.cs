using System;
using System.Collections.Generic;
using WpfOrganizer.Util;
using WpfOrganizer.Models;
using System.Windows.Input;
using WpfOrganizer.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfOrganizer.ViewModels
{
    class MainViewModel : Notifyer
    {
        private static MainViewModel currentInstance;
        public static MainViewModel inst
        {
            get => currentInstance;
            set { }
        }

        #region Команды

        public ICommand RemoveImageCommand { get; }
        private bool OnCanRemoveImageCommand(object p) => true;
        private void OnRemoveImageCommand(object p)
        {
            var image = p as TaskImage;
            if (p == null) return;

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
            var checkListItem = new CheckListItem()
            {
                Name = "New Check List Item"
            };

            var checkList = new CheckList() { Name = "New Check List" };
            checkList.Items.Add(checkListItem);

            SelectedTask.CheckLists.Add(checkList);
        }
        
        public ICommand AddTaskCommand { get; }
        private bool OnCanAddTaskCommand(object p) => SelectedTask.IsValid();
        private void OnAddTaskCommand(object p)
        {
            SelectedTask.ForCreation = false;
            Tasks.Add(SelectedTask);
            //SetupTaskForCreation();
        }

        public ICommand SetCreationMode { get; }
        private bool OnCanSetCreationMode(object p) => !SelectedTask.ForCreation;
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

        #endregion

        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks { get => tasks; set => Set(ref tasks, value); }

        // Используется не только для выборки, но и для создания
        private Task selectedTask;
        public Task SelectedTask { get => selectedTask; set => Set(ref selectedTask, value); }

        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags { get => tags; set => Set(ref tags, value); }

        private Tag creatingTag;
        public Tag CreatingTag { get => creatingTag; set => Set(ref creatingTag, value); }

        public MainViewModel()
        {
            currentInstance = this;

            #region Команды

            AddImageCommand = new LambdaCommand(OnAddImageCommand, OnCanAddImageCommand);
            SetCreationMode = new LambdaCommand(OnSetCreationMode, OnCanSetCreationMode);
            CreateTagCommand = new LambdaCommand(OnCreateTagCommand, OnCanCreateTagCommand);
            AddCheckListCommand = new LambdaCommand(OnAddCheckListCommand, OnCanAddCheckListCommand);
            AddTaskCommand = new LambdaCommand(OnAddTaskCommand, OnCanAddTaskCommand);
            RemoveSelectedTaskCommand = new LambdaCommand(OnRemoveSelectedTaskCommand, OnCanRemoveSelectedTaskCommand);
            RemoveImageCommand = new LambdaCommand(OnRemoveImageCommand, OnCanRemoveImageCommand);

            #endregion

            #region Инициализация

            SelectedTask = new Task();
            CreatingTag = new Tag();

            Tasks = new ObservableCollection<Task>();
            Tags = new ObservableCollection<Tag>();            
            Tags.CollectionChanged += Tags_CollectionChanged;

            SetupTaskForCreation();

            #endregion 
        }

        private void SetupTaskForCreation()
        {
            SelectedTask = new Task();
            SelectedTask.ForCreation = true;
        }

        private void Tags_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Tags");
        }
    }
}
