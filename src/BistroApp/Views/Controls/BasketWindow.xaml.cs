using System.Windows;

namespace SystemePAC.Views.Controls
{
    /// <summary>
    /// Interaction logic for BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        public BasketWindow()
        {
            InitializeComponent();
            var viewModel= new ViewModels.Controls.BasketWindowViewModel();
            DataContext = viewModel;
        }
        private void BtnAddClick(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ViewModels.Controls.BasketWindowViewModel).OnDeleteClickCommand((sender as System.Windows.Controls.Button).Tag);
        }
    }
}
