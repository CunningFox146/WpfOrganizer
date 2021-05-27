using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
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
            // Эф
            AppSettings.NotifyOn60 = Notify60;
            AppSettings.NotifyOn15 = Notify15;
            AppSettings.NotifyOn5 = Notify5;
            AppSettings.NotifyOn1 = Notify1;
            AppSettings.NotifyOnExpired = NotifyExpired;
        }

        public ICommand ChangeNameCommand { get; }
        private bool OnCanChangeNameCommand(object p) => true;
        private void OnChangeNameCommand(object p)
        {
            var name = (string)p;
            if (name == null || String.IsNullOrEmpty(name)) return;
            if (Users.Inst.TryChangeNameForCurrentUser(name))
            {
                NotificationsManager.NotifyNameChanged(name);
            }
            else
            {
                NotificationsManager.NotifyNameChangeFailed();
            }
        }

        public ICommand LogOutCommand { get; }
        private bool OnCanLogOutCommand(object p) => true;
        private void OnLogOutCommand(object p)
        {
            MainWindowViewModel.Inst.CurrentView = AppViews.Login;
        }

        public ICommand ChangePasswordCommand { get; }
        private bool OnCanChangePasswordCommand(object p) => true;
        private void OnChangePasswordCommand(object p)
        {
            PasswordBox pwBox = p as PasswordBox;
            if (Users.Inst.TryChangePasswordForCurrentUser(pwBox.Password))
            {
                NotificationsManager.NotifyPasswordChanged();
            }
            else
            {
                NotificationsManager.NotifyPasswordChangeFailed();
            }
        }

        public ICommand ChangeAvatarCommand { get; }
        private bool OnCanChangeAvatarCommand(object p) => true;
        private void OnChangeAvatarCommand(object p)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";

            if (dlg.ShowDialog() == true)
            {
                Users.Inst.ChangeAvatarForCurrentUser(dlg.FileName);
                NotificationsManager.NotifyAvatarChanged();
            }
        }

        #endregion

        private User currentUser;
        public User CurrentUser { get => currentUser; set => Set(ref currentUser, value); }

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
            ChangeNameCommand = new LambdaCommand(OnChangeNameCommand, OnCanChangeNameCommand);
            LogOutCommand = new LambdaCommand(OnLogOutCommand, OnCanLogOutCommand);
            ChangePasswordCommand = new LambdaCommand(OnChangePasswordCommand, OnCanChangePasswordCommand);
            ChangeAvatarCommand = new LambdaCommand(OnChangeAvatarCommand, OnCanChangeAvatarCommand);

            #endregion

            Notify60 = AppSettings.NotifyOn60;
            Notify15 = AppSettings.NotifyOn15;
            Notify5 = AppSettings.NotifyOn5;
            Notify1 = AppSettings.NotifyOn1;
            NotifyExpired = AppSettings.NotifyOnExpired;

            CurrentUser = Users.Inst.CurrentUser;
            Users.Inst.OnUserChanged += Users_OnUserChanged;
        }


        private void Users_OnUserChanged(User user)
        {
            CurrentUser = user;
        }
    }
}
