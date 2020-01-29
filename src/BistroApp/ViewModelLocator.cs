namespace SystemePAC
{
    public class ViewModelLocator
    {
        public ViewModels.Pages.LoginPageViewModel LoginPageViewModel => new ViewModels.Pages.LoginPageViewModel(App.Navigation);
        public ViewModels.Pages.LoginPageViewModel MainPageViewModel => new ViewModels.Pages.LoginPageViewModel(App.Navigation);
    }
}
