using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SystemePAC.Views.Controls.ConfigPages
{
    /// <summary>
    /// Interaction logic for ConfigMenuPage.xaml
    /// </summary>
    public partial class ConfigMenuPage : Page, INotifyPropertyChanged
    {
        private bool _isGrdAddEditVisible;
        private DateTime _dmDate = DateTime.Now;
        private bool _isCreateMode;
        private bool _isEditMode;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<FoodProduct> AllItemsLst { get; set; }
        public ObservableCollection<FoodProduct> SelectedItemsLst { get; set; }

        public ObservableCollection<DailyMenu> DailyFoodProductsLst { get; set; }

        public bool IsGrdAddEditVisible
        {
            get => _isGrdAddEditVisible;
            set
            {
                if (_isGrdAddEditVisible == value) return;
                _isGrdAddEditVisible = value;
                OnPropertyChanged(nameof(IsGrdAddEditVisible));
            }
        }

        public DateTime DmDate
        {
            get => _dmDate;
            set
            {
                if (_dmDate == value) return;
                _dmDate = value;
                OnPropertyChanged(nameof(DmDate));
            }
        }

        public ConfigMenuPage()
        {
            InitializeComponent();
            DataContext = this;

            LoadDbDailyFoodProducts();
            SelectedItemsLst = new ObservableCollection<FoodProduct>();
            LvSelectedItems.ItemsSource = SelectedItemsLst;
        }

        private void LoadDbFoodProducts()
        {
            using (var db = new DbManager.ApplicationDbContext())
            {
                var query = db.FoodProducts.Where(x => x.MiCategory == Help.FoodCategory.Cooked.ToString() || x.MiCategory == Help.FoodCategory.Soup.ToString());
                AllItemsLst = new ObservableCollection<FoodProduct>(query);
            }
            LvAllItems.ItemsSource = AllItemsLst;
        }

        private void LoadDbDailyFoodProducts()
        {
            using (var db = new DbManager.ApplicationDbContext())
            {
                var query = db.DailyMenus;
                DailyFoodProductsLst = new ObservableCollection<DailyMenu>(query);
            }
            LvDailyMenu.ItemsSource = DailyFoodProductsLst;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            _isCreateMode = !_isCreateMode;
            IsGrdAddEditVisible = _isCreateMode;
            if (_isCreateMode == false) return;
            IsGrdAddEditVisible = true;
            SelectedItemsLst.Clear();
            LoadDbFoodProducts();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            _isCreateMode = false;
            _isEditMode = !_isEditMode;
            if (!(LvDailyMenu.SelectedItem is DailyMenu dm))
            {
                _isEditMode = false;
                IsGrdAddEditVisible = false;
                return;
            }

            IsGrdAddEditVisible = true;
            SelectedItemsLst.Clear();
            LoadDbFoodProducts();
            LoadItemsForSelectedDailyMenu();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            _isEditMode = false;
            _isCreateMode = false;
            IsGrdAddEditVisible = false;
            using (var dataContext = new DbManager.ApplicationDbContext())
            {
                if (!(LvDailyMenu.SelectedItem is DailyMenu dm)) return;
                dataContext.DailyMenus.Remove(dm);
                dataContext.SaveChanges();
                App.Log.Info("Delete menu item menu with ID=" + dm.DmId);
            }
            LoadDbDailyFoodProducts();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!(LvAllItems.SelectedItem is FoodProduct item)) return;
            SelectedItemsLst.Add(item);
            AllItemsLst.Remove(item);
        }

        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (!(LvSelectedItems.SelectedItem is FoodProduct item)) return;
            AllItemsLst.Add(item);
            SelectedItemsLst.Remove(item);
        }

        private void BtnConfirmation_Click(object sender, RoutedEventArgs e)
        {
            var dm = LvDailyMenu.SelectedItem as DailyMenu;
            if (dm == null &&_isEditMode) return;

            using (var dataContext = new DbManager.ApplicationDbContext())
            {
                if (_isCreateMode)
                {
                    dm = new DailyMenu { DmDate = DmDate, DmId = Guid.NewGuid(), DmItems = string.Join(";", SelectedItemsLst.Select(x => x.MiId).ToList()) };
                    dataContext.DailyMenus.Add(dm);
                    App.Log.Info("Create daily menu with ID=" + dm.DmId);
                }
                else
                {
                    dm.DmDate = DmDate;
                    dm.DmItems = string.Join(";", SelectedItemsLst.Select(x => x.MiId).ToList());
                    dataContext.DailyMenus.Update(dm);
                    App.Log.Info("Update daily menu with ID=" + dm.DmId);
                }
                dataContext.SaveChanges();

            }
            LoadDbDailyFoodProducts();
            _isEditMode = false;
            _isCreateMode = false;
        }

        private void LoadItemsForSelectedDailyMenu()
        {
            if (!(LvDailyMenu.SelectedItem is DbManager.Models.DailyMenu dm && dm.DmItems != null)) return;
            var lstStringGUIDs = dm.DmItems?.Split(';');
            if (lstStringGUIDs.Length < 0) return;
            var lst = new List<Guid>();
            foreach (var sGuid in lstStringGUIDs)
            {

                if (!Guid.TryParse(sGuid, out var guid)) continue;
                lst.Add(guid);
                AllItemsLst.Remove(AllItemsLst.FirstOrDefault(x => x.MiId == guid));
            }

            using (var db = new DbManager.ApplicationDbContext())
            {
                var query = db.FoodProducts.Where(x => lst.Contains(x.MiId));
                SelectedItemsLst = new ObservableCollection<FoodProduct>(query);
                LvSelectedItems.ItemsSource = SelectedItemsLst;
            }
            DmDate = dm.DmDate;
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }
    }
}
