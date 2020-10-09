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
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Interop;

namespace ClipboardManager.Models
{
    public class Controller
    {
        public static ObservableCollection<IDataItem> Items = new ObservableCollection<IDataItem>() { };

        public Controller()
        {
            ClipboardNotification.ClipboardUpdate += (s,e)=>AddItem();
        }

        //Флаги сбора данных
        public bool IsCollectingText = true;
        public bool IsCollectingFile = true;
        public bool IsCollectingImage = true;

        public void AddItem()
        {
            IDataItem item = GetClipboardData();

            if (item is TextData && !IsCollectingText)
                return;
            if (item is FileData && !IsCollectingFile)
                return;
            if (item is ImageData && !IsCollectingImage)
                return;

            bool cancel = false;
            foreach(IDataItem i in Items)
            {
                //Валидаия Текста
                if (item is TextData && i is TextData && item.ItemText == i.ItemText) 
                {
                    cancel = true;
                }
                //Валидация Файлов
                if(item is FileData && i is FileData && ((StringCollection)item.Content).Count == ((StringCollection)i.Content).Count)
                {
                    var itemCol = (StringCollection)item.Content;
                    var iCol = (StringCollection)i.Content;
                    for (int k =0;k<iCol.Count;k++)
                    {
                        if (iCol[k] == itemCol[k])
                            cancel = true;
                    }
                }
                //Валидация картинок
                if (item is ImageData && i is ImageData)
                {
                    
                }
            }
            if (cancel)
                return;
            Items.Add(item);
            
        }
        #region ImagesComparer
        //bool ImagesAreDifferent(System.Drawing.Image img1, System.Drawing.Image img2)
        //{
        //    Bitmap bmp1 = new Bitmap(img1);
        //    Bitmap bmp2 = new Bitmap(img2);

        //    bool different = false;
        //    if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height)
        //    {
        //        for (int i = 0; i < bmp1.Width; i++)
        //        {
        //            for (int j = 0; j < bmp1.Height; j++)
        //            {
        //                System.Drawing.Color col1 = bmp1.GetPixel(i, j);
        //                System.Drawing.Color col2 = bmp2.GetPixel(i, j);
        //                if (col1 != col2)
        //                {
        //                    i = bmp1.Width + 1;
        //                    different = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return different;
        //}
        #endregion
        private IDataItem GetClipboardData()
        {
            if (Clipboard.ContainsText())
            {
                return new TextData();
            }
            else if (Clipboard.ContainsFileDropList())
            {
                return new FileData();
            }
            else if (Clipboard.ContainsImage())
            {
                return new ImageData();
            }
            else
            {
                return new UnknownData();
            }
        }

        public void SetClipboardData(IDataItem item)
        {
            if(item is TextData)
                Clipboard.SetText((string)item.Content);
            else if(item is FileData)
                Clipboard.SetFileDropList((StringCollection)item.Content);
            else if(item is ImageData)
                Clipboard.SetImage((BitmapSource)item.Content);
        }

        public void DeleteAllClips()
        {
            foreach(IDataItem item in Items)
            {
                if(item is FileData)
                {
                    foreach(string path in (StringCollection)item.Content)
                    {
                        if (File.Exists(path))
                        {
                            
                            File.Delete(path);
                        }
                        else if (Directory.Exists(path))
                            Directory.Delete(path, true);
                    }
                }
            }
            Items.Clear();
        }
    }
}
