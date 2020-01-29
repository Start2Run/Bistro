using SystemePAC.Help;
using SystemePAC.Help.Language;

namespace SystemePAC.ViewModels.Pages
{
    public partial class MainPageViewModel : GalaSoft.MvvmLight.ObservableObject
    {
        private readonly INavigationService navigationService;
        private float _totalPrice;
        private int _cartItemsCount;
        private LanguageEnum _appLanguage;
        private bool _isRefundChecked;
        private bool _isModeAdmin;

        public System.Windows.Input.ICommand BasketClickCommand { get; set; }
        public System.Windows.Input.ICommand ConfirmClickCommand { get; set; }
        public System.Windows.Input.ICommand FoodCategoriesClickCommand { get; set; }
        public System.Windows.Input.ICommand LanguageClickCommand { get; set; }
        public System.Windows.Input.ICommand ConfigClickCommand { get; set; }

        public LanguageEnum AppLanguage
        {
            get => _appLanguage;
            set
            {
                if (_appLanguage == value) return;
                _appLanguage = value;
                RaisePropertyChanged();
            }
        }
        public System.Collections.Generic.List<Models.BasketItem> BasketItems { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<DbManager.Models.FoodProduct> FoodProductsCollection { get; set; }
        public float TotalPrice
        {
            get => _isRefundChecked ? -_totalPrice : _totalPrice;
            set
            {
                if (_totalPrice == value) return;
                _totalPrice = value;
                RaisePropertyChanged(nameof(TotalPrice));
            }
        }
        public int CartItemsCount
        {
            get => _cartItemsCount;
            set
            {
                if (_cartItemsCount == value) return;
                _cartItemsCount = value;
                RaisePropertyChanged(nameof(CartItemsCount));
            }
        }
        public bool IsRefundChecked
        {
            get => _isRefundChecked;
            set
            {
                if (_isRefundChecked == value) return;
                _isRefundChecked = value;
                RaisePropertyChanged(nameof(IsRefundChecked));
                RaisePropertyChanged(nameof(TotalPrice));
            }
        }
        public bool IsModeAdmin
        {
            get => _isModeAdmin;
            set
            {
                if (_isModeAdmin == value) return;
                _isModeAdmin = value;
                RaisePropertyChanged(nameof(IsModeAdmin));
            }
        }
        public string UserName { get; set; }
    }
}