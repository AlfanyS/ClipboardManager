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
    public class MinimizeWindowCommand : ICommand
    {
        public event Action MinimizeMethod;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MinimizeMethod.Invoke();
        }
    }
}
