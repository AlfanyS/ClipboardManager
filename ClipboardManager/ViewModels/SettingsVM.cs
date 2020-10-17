using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClipboardManager.Commands;

namespace ClipboardManager.ViewModels
{
    public class SettingsVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SettingsVM()
        {
            MessageBox.Show(System.Windows.SystemParameters.WorkArea.Height.ToString());
        }

        private double _ScreenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
        public double ScreenHeight
        {
            get 
            {
                OnPropertyChanged("ScreenHeight");
                return _ScreenHeight;
            }
        }
        public CloseWindowCommand CloseWindow { get; set; } = new CloseWindowCommand();

    }
}
