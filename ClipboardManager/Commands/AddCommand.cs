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
    public class AddCommand : ICommand
    {
        Controller controller = MainVM.controller;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (MainVM.currentIndex == -1)
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            //MessageBox.Show(MainVM.currentIndex.ToString());
            controller.SetClipboardData(Controller.Items[MainVM.currentIndex]);
        }
    }
}
