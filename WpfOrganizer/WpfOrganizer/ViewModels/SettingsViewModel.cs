using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using WpfOrganizer.Commands;
using WpfOrganizer.Models;

namespace WpfOrganizer.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        #region Команды

        public ICommand ChangeThemeCommand { get; }
        private bool OnCanChangeThemeCommand(object p) => true;
        private void OnChangeThemeCommand(object p)
        {
            AppSettings.ChangeTheme(currentColor);
        }

        public ICommand BackCommand { get; }
        private bool OnCanBackCommand(object p) => true;
        private void OnBackCommand(object p)
        {
            MainWindowViewModel.Inst.CurrentView = AppViews.Main;
        }

        public ICommand UpdateNotificationCommand { get; }
        private bool OnCanUpdateNotificationCommand(object p) => true;
        private void OnUpdateNotificationCommand(object p)
        {
            AppSettings.NotifyOn60 = Notify60;
            AppSettings.NotifyOn15 = Notify15;
            AppSettings.NotifyOn5 = Notify5;
            AppSettings.NotifyOn1 = Notify1;
            AppSettings.NotifyOnExpired = NotifyExpired;
        }

        #endregion

        private Color currentColor;
        public Color CurrentColor { get => currentColor; set => Set(ref currentColor, value); }

        private bool notify60;
        public bool Notify60 { get => notify60; set => Set(ref notify60, value); }
        private bool notify15;
        public bool Notify15 { get => notify15; set => Set(ref notify15, value); }
        private bool notify5;
        public bool Notify5 { get => notify5; set => Set(ref notify5, value); }
        private bool notify1;
        public bool Notify1 { get => notify1; set => Set(ref notify1, value); }
        private bool notifyExpired;
        public bool NotifyExpired { get => notifyExpired; set => Set(ref notifyExpired, value); }

        public SettingsViewModel()
        {
            #region Команды

            ChangeThemeCommand = new LambdaCommand(OnChangeThemeCommand, OnCanChangeThemeCommand);
            BackCommand = new LambdaCommand(OnBackCommand, OnCanBackCommand);
            UpdateNotificationCommand = new LambdaCommand(OnUpdateNotificationCommand, OnCanUpdateNotificationCommand);

            #endregion

            Notify60 = AppSettings.NotifyOn60;
            Notify15 = AppSettings.NotifyOn15;
            Notify5 = AppSettings.NotifyOn5;
            Notify1 = AppSettings.NotifyOn1;
            NotifyExpired = AppSettings.NotifyOnExpired;
        }
    }
}
