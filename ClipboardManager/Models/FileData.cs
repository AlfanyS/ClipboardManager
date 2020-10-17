using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace ClipboardManager.Models
{
    class FileData : IDataItem
    {
        public string ItemText { get; set; }
        public string IconPath { get; } = @"\Resources\DataTypesImages\File.png";
        public object Content { get; set; }
        public string ToolTip { get; set; }
        public FileData()
        {
            object clipboard = null;
            try
            {
                clipboard = Clipboard.GetFileDropList();
            }
            catch
            {
                Thread.Sleep(100);
                clipboard = Clipboard.GetFileDropList();
            }
            SaveDataToLocal(clipboard);
            //Установка текста для списка
            for (int k = 0; k < ((StringCollection)clipboard).Count; k++)
            {
                ItemText +=  $"{k}. " + Path.GetFileName(((StringCollection)clipboard)[k]) + "\n";
            }
            for (int k = 0; k < ((StringCollection)clipboard).Count; k++)
            {
                ToolTip += $"{k}. " + ((StringCollection)clipboard)[k] + "\n";
            }


        }

        public void SaveDataToLocal(object c)
        {
            var _clipboard = (StringCollection)c;
            var collectionToAdd = new StringCollection();
            for (int k = 0; k < _clipboard.Count; k++)
            {
                if ( File.Exists(_clipboard[k]) )
                {
                    if (!File.Exists(Path.Combine(@".\Data", Path.GetFileName(_clipboard[k]))))
                    {
                        File.Copy(_clipboard[k], Path.Combine(@".\Data", Path.GetFileName(_clipboard[k])));
                        File.SetAttributes(Path.Combine(@".\Data", Path.GetFileName(_clipboard[k])), FileAttributes.Normal);
                    }

                    collectionToAdd.Add(Path.Combine(Environment.CurrentDirectory, "Data", Path.GetFileName(_clipboard[k])));
                }
                else if (Directory.Exists(_clipboard[k]))
                {
                    DirectoryInfo CopiedtDir = new DirectoryInfo(_clipboard[k]);
                    if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data", CopiedtDir.Name)))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data", CopiedtDir.Name));
                        FileInfo[] DirFiles = CopiedtDir.GetFiles();
                        foreach(FileInfo file in DirFiles)
                        {
                            File.Copy(file.FullName, Path.Combine(@".\Data", CopiedtDir.Name, file.Name));
                            File.SetAttributes(Path.Combine(@".\Data", CopiedtDir.Name, file.Name), FileAttributes.Normal);
                        }
                    }
                    collectionToAdd.Add(Path.Combine(Environment.CurrentDirectory, "Data", CopiedtDir.Name));
                }
            }
            Content = collectionToAdd;
        }
    }
}
