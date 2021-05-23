﻿using System;
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

        public ICommand SetCreationMode { get; }
        private bool OnCanSetCreationMode(object p) => SelectedTask != null;
        private void OnSetCreationMode(object p)
        {
            CreatingTask = !CreatingTask;
            SelectedTask = null;
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

        private bool creatingTask = false;
        public bool CreatingTask { get => creatingTask; set => Set(ref creatingTask, value); }

        public MainViewModel()
        {
            #region Команды

            AddImageCommand = new LambdaCommand(OnAddImageCommand, OnCanAddImageCommand);
            SetCreationMode = new LambdaCommand(OnSetCreationMode, OnCanSetCreationMode);
            CreateTagCommand = new LambdaCommand(OnCreateTagCommand, OnCanCreateTagCommand);

            #endregion

            CreatingTag = new Tag();

            currentInstance = this;

            var Rng = new Random();

            Tags = new ObservableCollection<Tag>();
            
            Tags.CollectionChanged += Tags_CollectionChanged;

            //Tags.Add(new Tag() { Name = "Tag1", Colour = "#f4fc03" });
            //Tags.Add(new Tag() { Name = "Tag2", Colour = "#fca503" });
            //Tags.Add(new Tag() { Name = "Tag3", Colour = "#fc0303" });

            Tasks = new ObservableCollection<Task>();

            for (int i = 0; i < 10; i++)
            {
                var dbgTask = new Task()
                {
                    Name = "Task " + i,
                    Description = "Long and cool desc actually....",
                    Checked = i % 2 == 0
                };
                
                for (int v = 0; v <= Rng.Next()%5; v++)
                {
                    var checkList = new CheckList();
                    checkList.Name = "Check list " + v;
                    checkList.Items.Add(new CheckListItem() { Name = "Name", Checked = false });
                    checkList.Items.Add(new CheckListItem() { Name = "Name1", Checked = true });
                    checkList.Items.Add(new CheckListItem() { Name = "Name2", Checked = true });
                    dbgTask.CheckLists.Add(checkList);
                }


                Tasks.Add(dbgTask);
            }
        }

        private void Tags_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Tags");
        }
    }
}
