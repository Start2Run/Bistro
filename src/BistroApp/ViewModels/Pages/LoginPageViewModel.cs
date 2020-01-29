using SystemePAC.Help;
using System.Windows;

namespace SystemePAC.ViewModels.Pages
{
    public class LoginPageViewModel : GalaSoft.MvvmLight.ObservableObject
    {
        private static INavigationService _navigationService;
        private static Common.AccessControlUser _user;

        public static Common.AccessControlUser User
        {
            get => _user; set
            {
                
                if (value == null)
                {
                    App.Log.Info($"The user {_user.FullName} has log out");
                    _user = value;
                    return;
                }
                _user = value;
                Application.Current.Dispatcher.Invoke(() => _navigationService.Navigate(nameof(Views.Pages.MainPage)));
                App.Log.Info($"The user {_user.FullName} has logged with success");
            }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}