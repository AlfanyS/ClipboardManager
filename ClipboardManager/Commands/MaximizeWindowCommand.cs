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
    public class MaximizeWindowCommand : ICommand
    {
        public event Action MaximizeMethod;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MaximizeMethod.Invoke();
        }
    }
}
