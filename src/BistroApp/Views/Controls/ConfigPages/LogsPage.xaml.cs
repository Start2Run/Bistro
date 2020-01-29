using System.Linq;
using System.Windows.Controls;

namespace SystemePAC.Views.Controls.ConfigPages
{
    /// <summary>
    /// Interaction logic for LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            InitializeComponent();
            App.Log.Debug("LogsPage");
            using (var db = new DbManager.ApplicationDbContext())
            {
                Dg.ItemsSource = (from em in db.Logs
                                  select new { em.LogId, em.Date, em.Level, em.Logger, em.Message }).ToList();
            }
        }
    }
}
