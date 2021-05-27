using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfOrganizer.Commands;
using WpfOrganizer.Util;

namespace WpfOrganizer.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        #region Команды

        public ICommand BackCommand { get; }
        private bool OnCanBackCommand(object p) => true;
        private void OnBackCommand(object p)
        {
            MainWindowViewModel.Inst.CurrentView = AppViews.Login;
        }

        public ICommand RegisterCommand { get; }
        private bool OnCanRegisterCommand(object p) => !String.IsNullOrEmpty(Login);
        private void OnRegisterCommand(object p)
        {
            PasswordBox pwBox = p as PasswordBox;

            //SomeBlackBoxClass.ValidatePassword(UserName, pwBox.Password);
            MainWindowViewModel.Inst.CurrentView = AppViews.Main;
        }

        #endregion

        private string login;
        public string Login { get => login; set => Set(ref login, value); }

        //private string password;
        //public string Password { get => password, set => Set(ref password, value); }

        public RegisterViewModel()
        {
            #region Команды

            BackCommand = new LambdaCommand(OnBackCommand, OnCanBackCommand);
            RegisterCommand = new LambdaCommand(OnRegisterCommand, OnCanRegisterCommand);

            #endregion
        }
    }
}
