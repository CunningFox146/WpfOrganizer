using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Util;
using WpfOrganizer.Views;

namespace WpfOrganizer.ViewModels
{
    enum AppViews
    {
        Login,
        Registration,
        Main,
        Settings
    }

    class MainWindowViewModel : BaseViewModel
    {
        static private MainWindowViewModel instance;
        static public MainWindowViewModel Inst
        {
            get => instance;
            set
            {
                if (instance == null)
                    instance = value;
            }
        }

        private BaseViewModel selectedView;
        public BaseViewModel SelectedView { get => selectedView; set => Set(ref selectedView, value); }

        private BaseViewModel loginViewModel;
        private BaseViewModel registrationViewModel;
        private BaseViewModel mainViewModel;
        private BaseViewModel settingsViewModel;

        private AppViews currentView;
        public AppViews CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                switch (currentView)
                {
                    case (AppViews.Login):
                        SelectedView = (loginViewModel ?? (loginViewModel = new LoginViewModel()));
                        break;

                    case (AppViews.Registration):
                        SelectedView = (registrationViewModel ?? (registrationViewModel = new RegisterViewModel()));
                        break;

                    case (AppViews.Main):
                        SelectedView = (mainViewModel ?? (mainViewModel = new MainViewModel()));
                        break;

                    case (AppViews.Settings):
                        SelectedView = (settingsViewModel ?? (settingsViewModel = new SettingsViewModel()));
                        break;
                }
            }
        }

        public MainWindowViewModel()
        {
            Inst = this;
            CurrentView = AppViews.Login;
        }
    }
}
