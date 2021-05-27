using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfOrganizer.Commands;
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

            //SomeBlackBoxClass.ValidatePassword(UserName, pwBox.Password);
            MainWindowViewModel.Inst.CurrentView = AppViews.Main;
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

        //private string password;
        //public string Password { get => password, set => Set(ref password, value); }

        public LoginViewModel()
        {
            #region Команды

            RegisterCommand = new LambdaCommand(OnRegisterCommand, OnCanRegisterCommand);
            LoginCommand = new LambdaCommand(OnLoginCommand, OnCanLoginCommand);

            #endregion
        }
    }
}
