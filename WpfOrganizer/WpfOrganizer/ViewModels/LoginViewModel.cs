using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfOrganizer.Commands;
using WpfOrganizer.Models;
using WpfOrganizer.Util;

namespace WpfOrganizer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Команды

        public ICommand LoginCommand { get; }
        private bool OnCanLoginCommand(object p) => !String.IsNullOrEmpty(Login);
        private void OnLoginCommand(object p)
        {
            PasswordBox pwBox = p as PasswordBox;
            var users = Users.Inst;

            var user = users.TryLogin(Login, pwBox.Password);
            if (user != null)
            {
                users.CurrentUser = user;
                MainWindowViewModel.Inst.CurrentView = AppViews.Main;
            }
            else
            {
                NotificationsManager.NotifyWrongLoginInfo();
            }
        }

        public ICommand RegisterCommand { get; }
        private bool OnCanRegisterCommand(object p) => true;
        private void OnRegisterCommand(object p)
        {
            MainWindowViewModel.Inst.CurrentView = AppViews.Registration;
        }

        #endregion

        private string login;
        public string Login { get => login; set => Set(ref login, value); }

        public LoginViewModel()
        {
            #region Команды

            RegisterCommand = new LambdaCommand(OnRegisterCommand, OnCanRegisterCommand);
            LoginCommand = new LambdaCommand(OnLoginCommand, OnCanLoginCommand);

            #endregion
        }
    }
}
