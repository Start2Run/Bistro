using System.Windows;

namespace SystemePAC.Views.Controls
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private Help.NavigationService Navigation;
        public ConfigWindow()
        {
            InitializeComponent();
            Navigation = new Help.NavigationService(ConfigFrame);
            Home_Click(null, null);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate<ConfigPages.ConfigHomePage>();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate<ConfigPages.ConfigMenuPage>();
        }

        private void FoodItem_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate<ConfigPages.ConfigProductPage>();
        }

        private void Logs_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate<ConfigPages.LogsPage>();
        }
    }
}
