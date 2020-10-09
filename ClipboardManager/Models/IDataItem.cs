using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardManager.Models
{
    public interface IDataItem
    {
        public string ItemText { get; set; }

        public string IconPath {get;}

        public object Content { get; set; }

        public string ToolTip { get; set; }

        void SaveDataToLocal(object o);
    }
}
