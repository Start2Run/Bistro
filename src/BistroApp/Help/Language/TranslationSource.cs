using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using SystemePAC.Properties;

namespace SystemePAC.Help.Language
{
    public class TranslationSource : INotifyPropertyChanged
    {
        public static TranslationSource Instance { get; } = new TranslationSource();

        private readonly ResourceManager _resManager = new ResourceManager("SystemePAC.Properties.Strings.Resources", Assembly.GetExecutingAssembly());
        private CultureInfo _currentCulture = null;

        public string this[string key] => _resManager.GetString(key, _currentCulture);

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture == value) return;
                _currentCulture = value;
                var @event = PropertyChanged;
                @event?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
