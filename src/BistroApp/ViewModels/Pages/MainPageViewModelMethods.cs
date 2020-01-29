using DbManager.Models;
using System;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Xml;
using SystemePAC.Help;
using System.Threading.Tasks;

namespace SystemePAC.ViewModels.Pages
{
    public partial class MainPageViewModel
    {
        private void LoadTodayMenuFromDB()
        {
            //CreateTestMenuItem();

            using (var db = new DbManager.ApplicationDbContext())
            {
                var todayMenu = db.DailyMenus.FirstOrDefault(x => x.DmDate.Date == DateTime.Today.Date);
                if (todayMenu == null) return;
                var query = db.FoodProducts.Where(x => todayMenu.DmItems.Contains(x.MiId.ToString()));
                FoodProductsCollection.Clear();
                foreach (var item in query)
                {
                    FoodProductsCollection.Add(item);
                }
            }
        }

        private void CreateTestMenuItem()
        {
            BitmapImage bitmap = new BitmapImage();
            using (System.IO.FileStream stream = System.IO.File.OpenRead(@"D:\School\bistro-app\src\SystemePAC\Resources\foodItem.png"))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                stream.Close();
            }

            using (var dataContext = new DbManager.ApplicationDbContext())
            {
                dataContext.FoodProducts.Add(new FoodProduct { MiId = Guid.NewGuid(), MiName = "Frites", MiCategory = "MenuDuJour", MiImage = Common.ImageHelper.ConvertImageToByte(bitmap) });
                dataContext.SaveChanges();
            }
        }

        #region Events
        public void OnBtnAddClick(object obj)
        {
            if (!(obj is FoodProduct menuItem)) return;
            var item = BasketItems.Find(x => x.MiGuid == menuItem.MiId);
            if (item != null)
            {
                item.MiQuantity++;
                ItemsBasket_CollectionChanged();
                return;
            }
            BasketItems.Add(new Models.BasketItem { MiGuid = menuItem.MiId, MiName = menuItem.MiName, MiImage = menuItem.MiImage, MiPrice = menuItem.MiPrice, MiQuantity = 1 });
            ItemsBasket_CollectionChanged();
        }

        public void OnConfirmClickCommand()
        {
            var body = new Common.ErpBill { Total = TotalPrice, Products = BasketItems.Select(x => x.MiGuid).ToList(), User = LoginPageViewModel.User };

            Task<bool> task = Task.Run<bool>(async () => await Common.WebApiServerModule.WebApiCmd.Put("http://localhost:1234", "ERP", body));
            if (!task.Result)
            {
                App.Log.Info("Confirmation failed because the ERP system didn't responded");
                return;
            }
            App.Log.Info("Confirmation succeded");
            LoginPageViewModel.User = null;
            navigationService.Navigate(nameof(Views.Pages.LoginPage));
        }

        public void OnBasketClickCommand()
        {
            var basketWindow = new Views.Controls.BasketWindow();
            if (basketWindow.DataContext is Controls.BasketWindowViewModel viewModel)
            {
                viewModel.LoadBasket(BasketItems);
            }
            basketWindow.Owner = System.Windows.Application.Current.MainWindow;
            basketWindow.ShowDialog();

            if (basketWindow.Tag is System.Collections.Generic.List<Models.BasketItem> lst)
            {
                BasketItems.Clear();
                BasketItems.AddRange(lst);
                ItemsBasket_CollectionChanged();
            }
        }

        public void OnFoodCategorieClickCommand(Help.FoodCategory foodCategorie)
        {
            switch (foodCategorie)
            {
                case FoodCategory.Cooked:
                case FoodCategory.Soup:
                    LoadTodayMenuFromDB();
                    break;
                case FoodCategory.Wrap:
                case FoodCategory.Beverage:
                case FoodCategory.Snack:
                    LoadFoodByCategorie(foodCategorie);
                    break;
            }
        }

        private void LoadFoodByCategorie(FoodCategory categorie)
        {
            using (var db = new DbManager.ApplicationDbContext())
            {
                var query = db.FoodProducts.Where(x => x.MiCategory == categorie.ToString());
                FoodProductsCollection.Clear();
                foreach (var item in query)
                {
                    FoodProductsCollection.Add(item);
                }
            }
        }

        public void OnLanguageClickCommand()
        {
            AppLanguage = AppLanguage == Help.Language.LanguageEnum.En ? Help.Language.LanguageEnum.Fr : Help.Language.LanguageEnum.En;
            UpdateKey("Language", AppLanguage == Help.Language.LanguageEnum.En ? "en-US" : "fr-CA");
        }

        private void ItemsBasket_CollectionChanged()
        {
            var total = 0f;
            var qty = 0;
            foreach (var item in BasketItems)
            {
                total += item.MiPrice * item.MiQuantity;
                qty += item.MiQuantity;
            }
           
            TotalPrice = total;
            CartItemsCount = qty;
        }

        private void OnConfigClickCommand()
        {
            var basketWindow = new Views.Controls.ConfigWindow();
            basketWindow.Owner = System.Windows.Application.Current.MainWindow;
            basketWindow.ShowDialog();
        }
        #endregion

        private void UpdateKey(string strKey, string newValue)
        {
            App.SetLanguage(newValue);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\bin\\SystemePAC.exe.config");

            if (!KeyExists(strKey))
            {
                throw new ArgumentNullException("Key", "<" + strKey + "> does not exist in the configuration. Update failed.");
            }
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    childNode.Attributes["value"].Value = newValue;
            }
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\bin\\SystemePAC.exe.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
        private bool KeyExists(string strKey)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\bin\\SystemePAC.exe.config");

            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    return true;
            }
            return false;
        }
    }
}