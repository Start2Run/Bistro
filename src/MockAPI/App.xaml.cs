using System.Windows;

namespace MockAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ConsoleContent dc = new ConsoleContent();
        public App()
        {
            Common.WebApiServerModule.ServerModule.Start("http://localhost:1234", "ERP", (param) => { dc.ConsoleInput = param; });
        }
    }
}
