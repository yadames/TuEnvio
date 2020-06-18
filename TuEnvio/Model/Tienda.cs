using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TuEnvio.Model
{
    public class Tienda : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                NotifyPropertyChanged();
            }
        }

        private string _provincia;
        public string Provincia {
            get { return _provincia; }
            set
            {
                _provincia = value;
                NotifyPropertyChanged();
            }
        }

        private string _url;
        public string URL {
            get { return _url; }
            set
            {
                _url = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isEnable;
        public bool IsEnable {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                NotifyPropertyChanged();
            }
        }

        private bool _canSearch;
        public bool CanSearch {
            get { return _canSearch; }
            set
            {
                _canSearch = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
