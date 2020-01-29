using System.Windows;
namespace SystemePAC.Views
{
    /// <summary>
    /// Interaction logic for StartupPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
        }
    }
}
