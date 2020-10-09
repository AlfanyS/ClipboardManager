using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace ClipboardManager.Models
{
    class TextData : IDataItem
    {
        public string ItemText { get; set; }
        public string IconPath { get; } = @"\Resources\DataTypesImages\Text.png";
        public object Content { get; set; }
        public string ToolTip { get; set; }
        public TextData()
        {
            object clipboard = null;
            try
            {
                clipboard = Clipboard.GetText();
            }
            catch
            {
                Thread.Sleep(100);
                clipboard = Clipboard.GetText();
            }
            Content = clipboard;
            ItemText = (string)clipboard;
        }

        public void SaveDataToLocal(object o)
        {
            
        }
    }
}
