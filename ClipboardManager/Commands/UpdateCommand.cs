using ClipboardManager.Models;
using ClipboardManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClipboardManager.Commands
{
    public class UpdateCommand : ICommand
    {
        Controller controller = MainVM.controller;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            controller.AddItem();
        }
    }
}
