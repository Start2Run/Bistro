using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Configuration;
using System.Windows;
using SystemePAC.Help.Language;
using System.Reflection;

namespace SystemePAC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Help.NavigationService Navigation;
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public App()
        {
            using (var dbContext = new DbManager.ApplicationDbContext())
            {
                dbContext.Database.Migrate();
            }
            Common.WebApiServerModule.ServerModule.Start("http://localhost:5678", "AccessControl", (param) => 
            {
                if (ViewModels.Pages.LoginPageViewModel.User != null) return;
                var user = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.AccessControlUser>(param);
                ViewModels.Pages.LoginPageViewModel.User = user;
            });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetLanguage(ConfigurationManager.AppSettings["Language"] ?? Thread.CurrentThread.CurrentCulture.ToString());
            Views.MainWindow mainWindow = new Views.MainWindow();
            mainWindow.Show();
            log4net.Config.XmlConfigurator.Configure();
            Navigation = new Help.NavigationService(mainWindow.MyFrame);
            Navigation.Navigate<Views.Pages.LoginPage>();
        }

        public static void SetLanguage(string locale)
        {
            if (string.IsNullOrEmpty(locale)) locale = "en-US";
            TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(locale);
        }
    }
}
