using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MockAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Common.AccessControlUser> Users { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SpConsole.DataContext = App.dc;
            Loaded += MainWindow_Loaded;
            Users = new List<Common.AccessControlUser>
            {
                new Common.AccessControlUser{ Id=Guid.Parse("B747F9E8-C242-4A01-9E8C-4667219B3DF2").ToString(), FirstName="Jason", LastName="Tape", GroupType=0 },
                new Common.AccessControlUser{ Id=Guid.Parse("A72D756E-B63B-4268-ACB6-177854F0C5C2").ToString(), FirstName="Elie", LastName="Bora", GroupType=0 },
                new Common.AccessControlUser{ Id=Guid.Parse("ECD83C14-77D2-409F-8E5D-D502D101E234").ToString(), FirstName="Ben", LastName="Ten", GroupType=1 }
            };
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //InputBlock.KeyDown += InputBlock_KeyDown;
            //InputBlock.Focus();
        }

        //void InputBlock_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        dc.ConsoleInput = InputBlock.Text;
        //        dc.RunCommand();
        //        InputBlock.Focus();
        //        Scroller.ScrollToBottom();
        //    }
        //}
        private void User_OnClick(object sender, RoutedEventArgs e)
        {
            if (!((sender as Button).DataContext is Common.AccessControlUser user)) return;
            Task<bool> task = Task.Run<bool>(async () => await Common.WebApiServerModule.WebApiCmd.Put("http://localhost:5678", "AccessControl", user));
            var result = task.Result;
        }
    }
}
