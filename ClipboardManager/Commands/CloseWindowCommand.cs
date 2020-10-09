using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClipboardManager.Models;
using ClipboardManager.ViewModels;

namespace ClipboardManager.Commands
{
    public class CloseWindowCommand : ICommand
    {
        public event Action CloseMethod;

        public bool CloseState = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object param)
        {
            CloseState = bool.Parse((string)param);
            CloseMethod.Invoke();
            
        }
    }
}
