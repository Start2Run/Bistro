using System.Windows.Controls;

namespace SystemePAC.Views.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.Pages.LoginPageViewModel(App.Navigation);
        }
    }
}
