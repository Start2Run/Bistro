using System.Windows.Controls;

namespace SystemePAC.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel= new ViewModels.Pages.MainPageViewModel(App.Navigation);
            DataContext = viewModel;
        }

        private void BtnAddClick(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ViewModels.Pages.MainPageViewModel).OnBtnAddClick((sender as Button).Tag);
        }
    }
}
