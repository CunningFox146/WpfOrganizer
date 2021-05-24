﻿using System;
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
    class MainViewModel : Notifyer
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
            RemoveTagCommand = new LambdaCommand(OnRemoveTagCommand, OnCanRemoveTagCommand);
            AddCheckListCommand = new LambdaCommand(OnAddCheckListCommand, OnCanAddCheckListCommand);
            AddTaskCommand = new LambdaCommand(OnAddTaskCommand, OnCanAddTaskCommand);
            RemoveSelectedTaskCommand = new LambdaCommand(OnRemoveSelectedTaskCommand, OnCanRemoveSelectedTaskCommand);
            RemoveImageCommand = new LambdaCommand(OnRemoveImageCommand, OnCanRemoveImageCommand);
            AddCheckBoxCommand = new LambdaCommand(OnAddCheckBoxCommand, OnCanAddCheckBoxCommand);
            RemoveCheckListCommand = new LambdaCommand(OnRemoveCheckListCommand, OnCanRemoveCheckListCommand);
            RemoveCheckListItemCommand = new LambdaCommand(OnRemoveCheckListItemCommand, OnCanRemoveCheckListItemCommand);

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
