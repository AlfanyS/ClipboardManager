using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClipboardManager.ViewModels;
using ClipboardManager.Models;
using ClipboardManager.Commands;

namespace ClipboardManager.Views
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SettingsWindow SettingsWindow = new SettingsWindow();
		public MainVM VM = new MainVM();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = VM;
			if (!Directory.Exists(@".\Data"))
				Directory.CreateDirectory(@".\Data");
			VM.CloseWindow.CloseMethod += () => this.Close();
		}

		//Закрытие и сворачивание окна
        private void Window_Closing(object sender, CancelEventArgs e)
		{
			if (!VM.CloseWindow.CloseState)
			{
				e.Cancel = true;
				Hide();
			}
			SettingsWindow.Close();

		}
		
        private void TrayIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
			Show();
		}

        private void Listbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
			if(e.ClickCount == 2)
            {
				MainVM.controller.SetClipboardData(Controller.Items[MainVM.currentIndex]);
				Close();
			}
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
			this.DragMove();
		}

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow.ShowDialog();
        }
    }
}
