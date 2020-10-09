using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading;

namespace ClipboardManager.Models
{
    class ImageData : IDataItem
    {
        public string ItemText { get; set; }
        public string IconPath { get; } = @"\Resources\DataTypesImages\Image.png";
        public object Content { get; set; }
        public string ToolTip { get; set; }
        public BitmapSource ImageContent { get; set; }
        public ImageData()
        {
            object clipboard = null;
            try
            {
                clipboard = Clipboard.GetImage();
            }
            catch
            {
                Thread.Sleep(100);
                clipboard = Clipboard.GetImage();
            }
            Content = clipboard;
            ImageContent = (BitmapSource)clipboard;
        }

        public void SaveDataToLocal(object o)
        {
            
        }
    }
}
