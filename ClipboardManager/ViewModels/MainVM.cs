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
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainVM()
        {
            Controller.Items.CollectionChanged += (o, e) => { OnPropertyChanged("ListCount"); };
        }

        public static Controller controller = new Controller();

        public int ListCount { get { return Controller.Items.Count(); } set { OnPropertyChanged("ListCount"); } }

        private ObservableCollection<IDataItem> listboxItems = Controller.Items;
        public ObservableCollection<IDataItem> ListboxItems
        {
            get => listboxItems;
            set
            {
                listboxItems = value;
                OnPropertyChanged("ListboxItems");
            }
        }

        public static int currentIndex;
        public int CurrentIndex
        {
            get => currentIndex;
            set
            {
                currentIndex = value;
                OnPropertyChanged("CurrentIndex");
            }
        }

        public bool IsCollectingText { get { return controller.IsCollectingText; } set { controller.IsCollectingText = value; OnPropertyChanged(); } }
        public bool IsCollectingFile { get { return controller.IsCollectingFile; } set { controller.IsCollectingFile = value; OnPropertyChanged(); } }
        public bool IsCollectingImage { get { return controller.IsCollectingImage; } set { controller.IsCollectingImage = value; OnPropertyChanged(); } }

        public UpdateCommand Update { get; } = new UpdateCommand();
        public AddCommand Add { get; } = new AddCommand();
        public DelAllCommand DelAll { get; } = new DelAllCommand();
        public CloseWindowCommand CloseWindow { get; } = new CloseWindowCommand();



    }
}
