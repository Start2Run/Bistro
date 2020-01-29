using System;
using GalaSoft.MvvmLight;

namespace SystemePAC.Models
{
    public class BasketItem : ObservableObject
    {
        private string _miName;
        private byte[] _miImage;
        private float _miPrice;
        private int _miQuantity=0;

        public Guid MiGuid { get; set; }

        public string MiName
        {
            get => _miName;
            set
            {
                if (_miName != null && _miName == value) return;
                _miName = value;
                RaisePropertyChanged();
            }
        }
        public byte[] MiImage
        {
            get => _miImage;
            set
            {
                if (_miImage != null && _miImage == value) return;
                _miImage = value;
                RaisePropertyChanged();
            }
        }
        public float MiPrice
        {
            get => _miPrice;
            set
            {
                if (_miPrice == value) return;
                _miPrice = value;
                RaisePropertyChanged();
            }
        }
        public int MiQuantity
        {
            get => _miQuantity;
            set
            {
                if (_miQuantity == value) return;
                _miQuantity = value;
                RaisePropertyChanged();
            }
        }
    }
}
