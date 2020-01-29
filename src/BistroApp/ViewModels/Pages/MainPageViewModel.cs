using System.Collections.ObjectModel;
using SystemePAC.Help;
using SystemePAC.Help.Language;
using DbManager.Models;
using GalaSoft.MvvmLight.CommandWpf;

namespace SystemePAC.ViewModels.Pages
{
    public partial class MainPageViewModel
    {
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            BasketItems = new System.Collections.Generic.List<Models.BasketItem>();
            FoodProductsCollection=new ObservableCollection<FoodProduct>();
            LoadTodayMenuFromDB();
            InitRelayCommands();
            var lang = System.Configuration.ConfigurationManager.AppSettings["Language"] ?? "en-Us";
            AppLanguage = lang == "en-US" ? LanguageEnum.En : LanguageEnum.Fr;
            UserName = LoginPageViewModel.User.FullName;
            IsModeAdmin = LoginPageViewModel.User.GroupType == 1;
        }

        private void InitRelayCommands()
        {
            BasketClickCommand = new RelayCommand(OnBasketClickCommand);
            ConfirmClickCommand = new RelayCommand(OnConfirmClickCommand);
            FoodCategoriesClickCommand = new RelayCommand<FoodCategory>(OnFoodCategorieClickCommand);
            LanguageClickCommand = new RelayCommand(OnLanguageClickCommand);
            ConfigClickCommand = new RelayCommand(OnConfigClickCommand);
        }
    }
}