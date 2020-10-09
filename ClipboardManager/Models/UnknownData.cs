using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardManager.Models
{
    class UnknownData:IDataItem
    {
        public string ItemText { get; set; }
        public string IconPath { get; } = @"\Resources\DataTypesImages\Unknown.png";
        public object Content { get; set; }
        public string ToolTip { get; set; }

        public void SaveDataToLocal(object o)
        {
        }
    }
}
