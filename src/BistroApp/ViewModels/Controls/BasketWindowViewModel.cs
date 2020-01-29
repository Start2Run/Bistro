using System.Collections.Generic;
using System.Collections.ObjectModel;
using SystemePAC.Models;
using DbManager.Models;
using System.Linq;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace SystemePAC.ViewModels.Controls
{
    public class BasketWindowViewModel
    {
        public ObservableCollection<BasketItem> BasketItems { get; set; }
        public System.Windows.Input.ICommand DeleteClickCommand { get; set; }
        public System.Windows.Input.ICommand ConfirmClickCommand { get; set; }

        public BasketWindowViewModel()
        {
            DeleteClickCommand = new RelayCommand<BasketItem>(OnDeleteClickCommand);
            ConfirmClickCommand = new RelayCommand<Window>(OnConfirmClickCommand);
        }

        public void LoadBasket(IEnumerable<BasketItem> lst)
        {
            if (lst == null) return;
            BasketItems = new ObservableCollection<BasketItem>(lst);
        }

        public void OnDeleteClickCommand(object obj)
        {
            if (!(obj is BasketItem item)) return;
            BasketItems.Remove(item);
        }

        private void OnConfirmClickCommand(Window window)
        {
            if (window != null)
            {
                window.Tag = BasketItems.ToList();
            }
            window?.Close();
        }
    }
}
