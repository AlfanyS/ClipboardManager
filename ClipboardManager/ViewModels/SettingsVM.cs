using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using ClipboardManager.Commands;
using ClipboardManager.Models;

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
            ScreenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        public double ScreenHeight { get; set; }
        public CloseWindowCommand CloseWindow { get; set; } = new CloseWindowCommand();
    }
}
