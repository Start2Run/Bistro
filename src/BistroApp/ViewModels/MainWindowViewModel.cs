using GalaSoft.MvvmLight;

namespace SystemePAC.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _userName="blabla";

        public string UserName
        {
            get => _userName;
            set
            {
                if (value == _userName) return;
                    _userName = value;
                    RaisePropertyChanged(nameof(UserName));
            }
        }

        public MainWindowViewModel()
        {
        }
    }
}
