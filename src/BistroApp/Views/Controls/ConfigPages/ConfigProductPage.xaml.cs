using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SystemePAC.Help;
using DbManager.Models;
using Microsoft.Win32;

namespace SystemePAC.Views.Controls.ConfigPages
{
    /// <summary>
    /// Interaction logic for ConfigProductPage.xaml
    /// </summary>
    public partial class ConfigProductPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private FoodCategory _productCategory;
        private string _productName;
        private byte[] _productImage;
        private float _productPrice;
        private bool _isGrdAddEditVisible;
        private FoodCategory _productSelectedCategorie;
        private bool _isCreateMode;
        private bool _isEditMode;

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

        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName == value) return;
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public FoodCategory ProductCategory
        {
            get => _productCategory;
            set
            {
                if (_productCategory == value) return;
                _productCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
            }
        }
        public byte[] ProductImage
        {
            get => _productImage;
            set
            {
                if (_productImage == value) return;
                _productImage = value;
                OnPropertyChanged(nameof(ProductImage));
            }
        }
        public float ProductPrice
        {
            get => _productPrice;
            set
            {
                if (_productPrice == value) return;
                _productPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }
        public Help.FoodCategory ProductSelectedCategorie
        {
            get => _productSelectedCategorie;
            set
            {
                if (_productSelectedCategorie == value) return;
                _productSelectedCategorie = value;
                OnPropertyChanged(nameof(ProductSelectedCategorie));
            }
        }

        public ObservableCollection<DbManager.Models.FoodProduct> FoodProductItemLst { get; set; }

        public ConfigProductPage()
        {
            InitializeComponent();
            DataContext = this;
            LoadDbFoodProductItems();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            _isCreateMode = !_isCreateMode;
            IsGrdAddEditVisible = _isCreateMode;
            if (!_isCreateMode)
            {
                return;
            }
            ProductName = string.Empty;
            ProductCategory = Help.FoodCategory.Cooked;
            ProductPrice = 0;
            ProductImage = null;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            _isCreateMode = false;
            _isEditMode = !_isEditMode;

            if (!(LvFoodProductFoodProducts.SelectedItem is FoodProduct mi))
            {
                _isEditMode = false;
                IsGrdAddEditVisible =false;
                return;
            }
            IsGrdAddEditVisible = _isEditMode;
            ProductName = mi.MiName;
            Enum.TryParse(mi.MiCategory, out FoodCategory categorie);
            ProductCategory = categorie;
            ProductPrice = mi.MiPrice;
            ProductImage = mi.MiImage;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            _isEditMode = false;
            _isCreateMode = false;
            IsGrdAddEditVisible = false;
            using (var dataContext = new DbManager.ApplicationDbContext())
            {
                if (!(LvFoodProductFoodProducts.SelectedItem is FoodProduct mi)) return;
                dataContext.FoodProducts.Remove(mi);
                dataContext.SaveChanges();
                App.Log.Info("Delete menu item menu with ID=" + mi.MiId);
            }
            LoadDbFoodProductItems();
        }
        private void BtnConfirmation_Click(object sender, RoutedEventArgs e)
        {
            var mi = LvFoodProductFoodProducts.SelectedItem as FoodProduct;
            if (mi == null && _isEditMode == true) return;

            using (var dataContext = new DbManager.ApplicationDbContext())
            {
                if (_isCreateMode == true)
                {
                    mi = new FoodProduct() { MiName = ProductName, MiCategory = ProductCategory.ToString(), MiId = new Guid(), MiImage = ProductImage,MiPrice = ProductPrice};
                    dataContext.FoodProducts.Add(mi);
                    App.Log.Info("Create menu item menu with ID=" + mi.MiId);
                }
                else
                {
                    var selected = FoodProductItemLst.FirstOrDefault(x => x.MiId == mi.MiId);
                    selected.MiCategory = ProductCategory.ToString();
                    selected.MiName = ProductName;
                    selected.MiPrice = ProductPrice;
                    selected.MiImage = ProductImage;
                    dataContext.FoodProducts.Update(selected);
                    App.Log.Info("Update menu item menu with ID=" + mi.MiId);
                }
                dataContext.SaveChanges();
            }
            LoadDbFoodProductItems();
            _isCreateMode = false;
            _isEditMode = false;
            IsGrdAddEditVisible = false;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var filedialog = new OpenFileDialog();
            filedialog.ShowDialog();
            var bitmap = new BitmapImage();
            if (String.IsNullOrEmpty(filedialog.FileName)) return;
            using (System.IO.FileStream stream = System.IO.File.OpenRead(filedialog.FileName))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                stream.Close();
            }

            ProductImage = Common.ImageHelper.ConvertImageToByte(bitmap);
        }

        private void LoadDbFoodProductItems()
        {
            using (var db = new DbManager.ApplicationDbContext())
            {
                var query = db.FoodProducts;
                FoodProductItemLst = new ObservableCollection<FoodProduct>(query);
            }

            LvFoodProductFoodProducts.ItemsSource = FoodProductItemLst;
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }
    }
}
